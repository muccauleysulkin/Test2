using Test2.Data;
using Test2.Interfaces;
using Test2.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Test2.Service
{
    public class FixtureAndResultService : IFixtureAndResultService
    {

        private readonly ApplicationDbContext _context;

        public FixtureAndResultService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(FixtureAndResult fixtureAndResult)
        {
            _context.Add(fixtureAndResult);
            return Save();
        }

        public bool Delete(FixtureAndResult fixtureAndResult)
        {
            _context.Remove(fixtureAndResult);
            return Save();
        }

        public async Task<IEnumerable<FixtureAndResult>> GetAll()
        {
            return await _context.FixturesAndResults.ToListAsync();
        }

        public async Task<FixtureAndResult?> GetByIdAsync(int id)
        {
            
                return await _context.FixturesAndResults.FirstOrDefaultAsync(i => i.Match_id == id);
           
        }

        public async Task<FixtureAndResult?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.FixturesAndResults.AsNoTracking().FirstOrDefaultAsync(i => i.Match_id == id);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(FixtureAndResult fixtureAndResult)
        {
            _context.Update(fixtureAndResult);
            return Save();
        }
    }
}
