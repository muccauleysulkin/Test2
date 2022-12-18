using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Interfaces;
using Test2.Models;
using Test2.Service;
using Test2.ViewModels;

namespace Test2.Controllers
{
    public class LeagueController : Controller
    {
       // private readonly ApplicationDbContext _context;
        private readonly ILeagueService _leagueService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeagueController( ILeagueService leagueService, IHttpContextAccessor httpContextAccessor)
        {
            _leagueService = leagueService;
            _httpContextAccessor = httpContextAccessor;
           // _context = context;

        }


        public async Task<IActionResult> Index()
        {
            //List<League> leagues = _context.Leagues.ToList();
            //return View(leagues);
            IEnumerable<League> leagues = await _leagueService.GetAll();
            return View(leagues);
        }

        public async Task<IActionResult> Detail(int id)
        {
            League league = await _leagueService.GetByIdAsync(id);
            return View(league);
        }

        public async Task<IActionResult> Leaguetable()
        {
           
            return View();
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createLeagueViewModel = new CreateLeagueViewModel { BasketballNiId = curUserId };

            return View(createLeagueViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(League league)
        {
            if (!ModelState.IsValid)
            {
                
                return View(league);
            }
            _leagueService.Add(league);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var league = await _leagueService.GetByIdAsync(id);
            if (league == null) return View("Error");
            var leagueVM = new EditLeagueViewModel
            {
                Leaguename = league.Leaguename,
                LeagueDescription = league.LeagueDescription,
                Level = league.Level


            };
            return View(leagueVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditLeagueViewModel leagueVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit team information");
                return View(leagueVM);
            }

            //var userLeague = await _leagueService.GetByIdAsyncNoTracking(id); 
            

            var league = new League
            {
                League_id = id,
                Leaguename = leagueVM.Leaguename,
                LeagueDescription = leagueVM.LeagueDescription,
                Level = leagueVM.Level,
                
            };

            _leagueService.Update(league);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var leagueDetails = await _leagueService.GetByIdAsync(id);
            if (leagueDetails == null) return View("Error");
            return View(leagueDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            var leagueDetails = await _leagueService.GetByIdAsync(id);
            if (leagueDetails == null) return View("Error");

            _leagueService.Delete(leagueDetails);
            return RedirectToAction("Index");
        }


    }
}
