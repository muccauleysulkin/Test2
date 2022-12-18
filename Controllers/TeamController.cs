using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Interfaces;
using Test2.Models;
using Test2.ViewModels;
//using Test2.Helpers;

namespace Test2.Controllers
{
    public class TeamController : Controller
    {

        private readonly ITeamService _teamService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TeamController(ITeamService teamService, IHttpContextAccessor httpContextAccessor)
        {
            _teamService = teamService;
            _httpContextAccessor = httpContextAccessor;


        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Team> teams = await _teamService.GetAll();
            return View(teams);

            //List<Team> teams = _context.Teams.ToList();
            //return View(teams);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Team team = await _teamService.GetByIdAsync(id);
            return View(team);
        }


        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createTeamViewModel = new CreateTeamViewModel { BasketballNiId = curUserId };
               
            return View(createTeamViewModel);
        }


        

    [HttpPost]
    public async Task<IActionResult> Create(Team team)
    {
        if (!ModelState.IsValid)
        {

            return View(team);
        }
        _teamService.Add(team);
        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Edit(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if (team == null) return View("Error");
            var teamVM = new EditTeamViewModel
            {
                Name = team.Name,
                Description = team.Description,
                LeagueName = team.LeagueName
            };
            return View(teamVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTeamViewModel teamVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit team information");
                return View("Edit", teamVM);
            }

            var userTeam = await _teamService.GetByIdAsyncNoTracking(id);

            var team = new Team
            {
                Id = id,
                Name = teamVM.Name,
                Description = teamVM.Description,
                LeagueName = teamVM.LeagueName,
            };

            _teamService.Update(team);

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Delete (int id)
        {
            var teamDetails = await _teamService.GetByIdAsync(id);
            if (teamDetails == null) return View("Error");
            return View(teamDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var teamDetails = await _teamService.GetByIdAsync(id);
            if (teamDetails == null) return View("Error");

            _teamService.Delete(teamDetails);
            return RedirectToAction("Index");
        }

    }
}