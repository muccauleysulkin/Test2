using Test2.Data;
using Test2.Interfaces;
using Test2.Models;

namespace Test2.Service
{
    public class HubService : IHubService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HubService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        
        }

        public async Task<List<FixtureAndResult>> GetAllUserFixtureAndResults()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userFixtures = _context.FixturesAndResults.Where(t => t.BasketballNiId == curUser);
            return userFixtures.ToList();
        }

        public async Task<List<League>> GetAllUserLeagues()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userLeagues = _context.Leagues.Where(t => t.BasketballNiId == curUser);
            return userLeagues.ToList();
        }

        public async Task<List<Player>> GetAllUserPlayers()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userPlayers = _context.Players.Where(t => t.BasketballNiId == curUser);
            return userPlayers.ToList();
        }


        public async Task<List<Team>> GetAllUserTeams()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userTeams = _context.Teams.Where(t => t.BasketballNiId == curUser);
            return userTeams.ToList();
        }

    }
}
