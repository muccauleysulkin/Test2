using Test2.Models;

namespace Test2.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAll();
        // Task<Team> GetByIdAsync(int id);
        Task<IEnumerable<Team>> GetTeamByName(string name);

        Task<Team?> GetByIdAsync(int id);
        Task<Team?> GetByIdAsyncNoTracking(int id);

        bool Add(Team team);
        bool Update(Team team);
        bool Delete(Team team);
        bool Save();
    
    }
}
