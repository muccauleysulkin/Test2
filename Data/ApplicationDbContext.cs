using System.Collections.Generic;
using Test2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace Test2.Data
{
    public class ApplicationDbContext :  IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<FixtureAndResult> FixturesAndResults { get; set; }
    }
}