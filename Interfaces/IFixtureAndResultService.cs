using Test2.Models;

namespace Test2.Interfaces
{
    public interface IFixtureAndResultService
    {
        Task<IEnumerable<FixtureAndResult>> GetAll();

        //   Task<IEnumerable<Player>> GetPlayerByName(string name);

        Task<FixtureAndResult?> GetByIdAsync(int id);

        Task<FixtureAndResult?> GetByIdAsyncNoTracking(int id);

        bool Add(FixtureAndResult fixtureAndResult);
        bool Update(FixtureAndResult fixtureAndResult);

        bool Delete(FixtureAndResult fixtureAndResult);

        bool Save();
    }
}
