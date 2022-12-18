using Test2.Data;
using Test2.Interfaces;
using Test2.Models;
using Microsoft.EntityFrameworkCore;

namespace Test2.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Player player)
        {
            _context.Add(player);
            return Save();
        }

        public bool Delete(Player player)
        {
            _context.Remove(player);
            return Save();
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            //return await _context.Players.Include(i => i.Player_id).FirstOrDefaultAsync(x => x.Player_id == id);
            return await _context.Players.FirstOrDefaultAsync(i => i.Player_id == id);
        }

        public async Task<Player?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Players.AsNoTracking().FirstOrDefaultAsync(i => i.Player_id == id);

        }

        public async Task<IEnumerable<Player>> GetPlayerByName(string name)
        {
            return await _context.Players.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Player player)
        {
            _context.Update(player);
            return Save();
        }
    }
}
