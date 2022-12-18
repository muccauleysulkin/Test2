using Test2.Models;

namespace Test2.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAll();

     //   Task<IEnumerable<Player>> GetPlayerByName(string name);

        Task<Player?> GetByIdAsync(int id);

        Task<Player?> GetByIdAsyncNoTracking(int id);

        bool Add(Player player);
        bool Update(Player player);

        bool Delete(Player player);

        bool Save();

    }
}
