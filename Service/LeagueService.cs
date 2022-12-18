using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Interfaces;
using Test2.Models;

namespace Test2.Service
{
    public class LeagueService : ILeagueService
    {
        private readonly ApplicationDbContext _context;

        public LeagueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(League league)
        {
            _context.Add(league);
            return Save();
        }

        public bool Delete(League league)
        {
            _context.Remove(league);
            return Save();
        }

        public async Task<IEnumerable<League>> GetAll()
        {
            return await _context.Leagues.ToListAsync();
        }

        public async Task<League> GetByIdAsync(int id)
        {
            return await _context.Leagues.FirstOrDefaultAsync(i => i.League_id == id);
        }

        public async Task<League?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Leagues.AsNoTracking().FirstOrDefaultAsync(i => i.League_id == id);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(League league)
        {
            _context.Update(league);
            return Save(); 
        }
    }
}
