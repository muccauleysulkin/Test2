using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Models;
using Test2.Interfaces;
using Test2.Service;
using Test2.ViewModels;


namespace Test2.Controllers
{
    public class PlayerController : Controller
    {
        
        private readonly IPlayerService _playerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        // private readonly ApplicationDbContext _context;

        public PlayerController( IPlayerService playerService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _playerService= playerService;
            //_context = context;
        }


        public async Task<IActionResult> Index()
        {
            //IEnumerable<Player> players = await _playerService.GetAll();
            //return View(players);

            IEnumerable<Player> players = await _playerService.GetAll();
            return View(players);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Player player = await _playerService.GetByIdAsync(id);
            return View(player);
        }

        //public IActionResult Create()
        //{
        //    var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
        //    var createPlayerViewModel = new CreatePlayerViewModel { BasketballNiId = curUserId };

        //    return View(createPlayerViewModel);
        //}

        //public async Task<IActionResult> Create(Player player)
        //{
        //    if (!ModelState.IsValid)
        //    {

        //        return View(player);
        //    }
        //    _playerService.Add(player);
        //    return RedirectToAction("Index");

        //}

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createPlayerViewModel = new CreatePlayerViewModel { BasketballNiId = curUserId };

            return View(createPlayerViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            _playerService.Add(player);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null) return View("Error");
            var playerVM = new EditPlayerViewModel
            {
                Name = player.Name,
                TeamName = player.TeamName,
                Points = player.Points,
                Rebounds = player.Rebounds,
                Assists = player.Assists,
                Steals = player.Steals,
                Blocks = player.Blocks
            };

            return View(playerVM);
        }
        

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPlayerViewModel playerVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit team information");
                return View("Edit", playerVM);
            }

            var userPlayer = await _playerService.GetByIdAsyncNoTracking(id);

            var player = new Player 
            {
                Player_id = id,
                Name = playerVM.Name,
                TeamName =playerVM.TeamName,
                Points = playerVM.Points,
                Rebounds = playerVM.Rebounds,
                Assists = playerVM.Assists,
                Steals = playerVM.Steals,
                Blocks = playerVM.Blocks
            };

            _playerService.Update(player);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var playerDetails = await _playerService.GetByIdAsync(id);
            if (playerDetails == null) return View("Error");
            return View(playerDetails);
        }



        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var playerDetails =  await _playerService.GetByIdAsync(id);
            //var playerDetails = _context.Players.FirstOrDefault(o => o.Player_id == id);
            if (playerDetails == null) return View("Error");

            _playerService.Delete(playerDetails);
            return RedirectToAction("Index");
        }



    }
}
