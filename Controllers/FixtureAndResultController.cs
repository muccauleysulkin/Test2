using Microsoft.AspNetCore.Mvc;
using Test2.Data;
using Test2.Interfaces;
using Test2.Models;
using Test2.Service;
using Test2.ViewModels;

namespace Test2.Controllers
{
    public class FixtureAndResultController : Controller
    {
        private readonly IFixtureAndResultService _fixtureAndResultService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public FixtureAndResultController(IFixtureAndResultService fixtureAndResultService, IHttpContextAccessor httpContextAccessor)
        {
            _fixtureAndResultService = fixtureAndResultService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
            //List<FixtureAndResult> fixtureAndResults = _context.FixturesAndResults.ToList();
            //return View(fixtureAndResults);

            IEnumerable<FixtureAndResult> fixtureAndResults = await _fixtureAndResultService.GetAll();
            return View(fixtureAndResults);
        }

        public async Task<IActionResult> Detail(int id)
        {
            FixtureAndResult fixtureAndResult = await _fixtureAndResultService.GetByIdAsync(id);
            return View(fixtureAndResult);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createFixtureAndResultViewModel = new CreateFixtureAndResultViewModel { BasketballNiId = curUserId};
            return View(createFixtureAndResultViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(FixtureAndResult fixtureAndResult)
        {
            if (!ModelState.IsValid)
            {
                return View(fixtureAndResult);
            }
            _fixtureAndResultService.Add(fixtureAndResult);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var far = await _fixtureAndResultService.GetByIdAsync(id);
            if (far == null) return View("Error");
            var farVM = new EditFixtureAndResultViewModel
            {
                Hometeam = far.Hometeam,
                Awayteam = far.Awayteam,
                Homescore = far.Homescore,
                Awayscore = far.Awayscore,
                DatefGame = far.DatefGame

            };

            return View(farVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditFixtureAndResultViewModel farVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit team information");
                return View("Edit", farVM);
            }

            var userFar = await _fixtureAndResultService.GetByIdAsyncNoTracking(id);

            var far = new FixtureAndResult
            {
                Match_id = id,
                Hometeam = farVM.Hometeam,
                Homescore = farVM.Homescore,
                Awayteam = farVM.Awayteam,
                Awayscore = farVM.Awayscore,
                DatefGame = farVM.DatefGame
            };

            _fixtureAndResultService.Update(far);

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Delete(int id)
        {
            var farDetails = await _fixtureAndResultService.GetByIdAsync(id);
            if (farDetails == null) return View("Error");
            return View(farDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFixtureAndResult(int id)
        {
            var farDetails = await _fixtureAndResultService.GetByIdAsync(id);
            if (farDetails == null) return View("Error");

            _fixtureAndResultService.Delete(farDetails);
            return RedirectToAction("Index");
        }
    }
}
