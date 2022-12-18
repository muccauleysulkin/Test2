using System.Net;
using Microsoft.AspNetCore.Identity;
using Test2.Models;
using Test2.Data;



namespace Test2.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(new List<Team>()
                    {
                        new Team()
                        {
                            Name = "Omagh Thunder",
                            Description = "Club is based in Omagh and has existed since 1999 having won several underage and division 2 championships",
                            LeagueName = "Mens Premier League"

                         },
                        new Team()
                        {
                            Name = "Belfast Star",
                            Description = "One of the most prestigious and hsitoric clubs in Ireland, having won several superleague titles and routinely competintg at all levles and strving for success",
                            LeagueName = "Mens Premier League"

                        }
                    });
                    context.SaveChanges();
                }

                if (!context.FixturesAndResults.Any())
                {
                    context.FixturesAndResults.AddRange(new List<FixtureAndResult>()
                         {
                            new FixtureAndResult()
                            {
                                Hometeam = "Omagh",
                                Awayteam = "Belfast",
                                Homescore = "100",
                                Awayscore = "90",
                                DatefGame = "22nd September 2022"
                            },

                            new FixtureAndResult()
                            {
                                Hometeam = "Belfast",
                                Awayteam = "Omagh",
                                Homescore = "85",
                                Awayscore = "86",
                                DatefGame = "29th September 2022"
                            }
                        });
                    context.SaveChanges();
                }


                if (!context.Leagues.Any())
                {
                    context.Leagues.AddRange(new List<League>()
                        {
                            new League()
                            {
                                Leaguename ="Mens Premier League",
                                LeagueDescription = "The top mens league in northern Ireland which is made up of numerous teams and strives to promote basketball across Ireland",
                                Level ="Senior"
                            }
                        });
                    context.SaveChanges();

                }

                if (!context.Players.Any())
                {
                    context.Players.AddRange(new List<Player>()
                        {
                            new Player()
                            {
                                Name = "Katie",
                                TeamName = "Omagh",
                                Points = "25",
                                Rebounds = "13",
                                Assists = "4",
                                Blocks = "5",
                                Steals = "2"
                            },

                        new Player()
                            {
                                Name = "Connor",
                                TeamName = "Omagh",
                                Points = "21",
                                Rebounds = "11",
                                Assists = "0",
                                Blocks = "1",
                                Steals = "6"
                            },

                        new Player()
                            {
                                Name = "Patrick",
                                TeamName = "Belfast",
                                Points = "27",
                                Rebounds = "9",
                                Assists = "7",
                                Blocks = "2",
                                Steals = "1"
                            },

                        new Player()
                            {
                                Name = "Paul",
                                TeamName = "Belfast",
                                Points = "18",
                                Rebounds = "2",
                                Assists = "11",
                                Blocks = "3",
                                Steals = "1"
                            }
                        });
                    context.SaveChanges();

                }
            }

        }
                    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
                    {
                        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                        {
                            //Roles
                            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                             if (!await roleManager.RoleExistsAsync(UserRoles.Coach))
                                await roleManager.CreateAsync(new IdentityRole(UserRoles.Coach));
                            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                            //Users
                            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                            string adminUserEmail = "oisinbasketballadmin.com";

                            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                            if (adminUser == null)
                            {
                                var newAdminUser = new User()
                                {
                                    UserName = "Oisin",
                                    Email = adminUserEmail,
                                    EmailConfirmed = true,
                                    FavouritePlayer = "Me",
                                    FavouriteTeam = "Any",
                                    County = "The Best"

                                };
                                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                            }

                string coachUserEmail = "coachemaill.com";

                            var coachUser = await userManager.FindByEmailAsync(coachUserEmail);
                             if (coachUser == null)
                                {
                                 var newCoachUser = new User()
                                 {
                                    UserName = "BigEZ",
                                    Email = coachUserEmail,
                                    EmailConfirmed = true,
                                    FavouritePlayer = "Larry",
                                    FavouriteTeam = "North Star",
                                    County = "Derry"

                                  };
                    await userManager.CreateAsync(newCoachUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newCoachUser, UserRoles.Coach);
                }

                string appUserEmail = "user.com";

                            var appUser = await userManager.FindByEmailAsync(appUserEmail);
                            if (appUser == null)
                            {
                                var newAppUser = new User()
                                {
                                    UserName = "app-user",
                                    Email = appUserEmail,
                                    EmailConfirmed = true,
                                    FavouriteTeam = "Omagh",
                                    FavouritePlayer = "Jordan",
                                    County = "Kerry"

                                };
                                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                            }
                        }
                    }

                }
            }

        

    





