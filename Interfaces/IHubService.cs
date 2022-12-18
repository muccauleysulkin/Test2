using Test2.Models;

namespace Test2.Interfaces
{
    public interface IHubService
    {
        Task<List<Team>> GetAllUserTeams();

        Task<List<League>> GetAllUserLeagues();

        Task<List<Player>> GetAllUserPlayers();

        Task<List<FixtureAndResult>> GetAllUserFixtureAndResults();

        // Task<List<League>> GetAllUserLeagues();



        // Task<List<AllOtheres>> Get Them


    }
}
