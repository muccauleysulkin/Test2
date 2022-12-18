using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Interfaces;
using Test2.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Test2.Controllers
{
    public class HubController : Controller
    {

        private readonly IHubService _hubService;

        public HubController(IHubService hubService)
        {
            _hubService = hubService;
        }
        public async Task<IActionResult> Index()
        {
            var userTeams = await _hubService.GetAllUserTeams();
            var userLeagues = await _hubService.GetAllUserLeagues();
            var userPlayers = await _hubService.GetAllUserPlayers();
            var userFixtures = await _hubService.GetAllUserFixtureAndResults();


            // var userLeagues = await _hubService.GetAllUserLeagues();
            var hubViewModel = new HubViewModel()
            {
                Teams = userTeams,
                Leagues = userLeagues,
                Players = userPlayers,
                Fixtures = userFixtures


                // Leagues = userLeagues
            };
            return View(hubViewModel);
        }
    }
}
