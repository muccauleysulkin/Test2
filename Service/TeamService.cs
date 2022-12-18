using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Interfaces;
using Test2.Models;

namespace Test2.Service
{
    public class TeamService : ITeamService
    { 
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public bool Add(Team team)
        {
            _context.Add(team);
            return Save();
        }

        public bool Delete(Team team)
        {
            _context.Remove(team);
            return Save();
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Teams.FirstOrDefaultAsync(i => i.Id == id);

        }

        public async Task<Team?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Teams.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

        }



        public async Task<IEnumerable<Team>> GetTeamByName(string name)
        {
            return await _context.Teams.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Team team)
        {
            _context.Update(team);
            return Save();
        }
    }
}
