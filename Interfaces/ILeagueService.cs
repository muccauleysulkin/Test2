using Test2.Models;

namespace Test2.Interfaces
{
    public interface ILeagueService
    {
        Task<IEnumerable<League>> GetAll();

        //   Task<IEnumerable<Player>> GetPlayerByName(string name);

        Task<League?> GetByIdAsync(int id);

        Task<League> GetByIdAsyncNoTracking(int id);

        bool Add(League league);
        bool Update(League league);

        bool Delete(League league);

        bool Save();
    }
}
