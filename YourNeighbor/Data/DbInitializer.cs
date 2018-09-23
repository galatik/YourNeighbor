using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourNeighbor.Models;

namespace YourNeighbor.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserManager<User> userManager, ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            List<User> users;

            if (!context.Users.Any())
            {
                users = new List<User>();

                for (int i = 1; i <= 9; i++)
                {
                    var user = new User()
                    {
                        UserName = $"TestUser{i}",
                        FirstName = $"TestUser{i}",
                        LastName = $"TestUser{i}",
                        Birthday = new DateTime(1999, 7, 1),
                        Gender = Gender.Male,
                        SocialStatus = SocialStatus.Unemployed,
                        MaxCost = 20000,
                        MinCountOfRooms = 2,
                        AboutMe = "eqwfqwefqwefqewfqwefqwefqfqfqfqfqqf"
                    };

                    users.Add(user);

                    userManager.CreateAsync(user, $"TestUserPassword{i}@").Wait();
                }

            }
            else
            {
                users = context.Users.Take(9).ToList();
            }

            City city;

            List<Area> areas;

            if (!context.Cities.Any())
            {
                city = new City()
                {
                    Name = "Красноярск"
                };

                context.Cities.Add(city);

            } else
            {
                city = context.Cities.FirstOrDefault(c => c.Name == "Красноярск");
            }

            if (!context.Areas.Any())
            {
                areas = new List<Area>()
                {
                    new Area()
                    {
                        City = city,
                        AreaName = "Октябрьский район"
                    },
                    new Area()
                    {
                        City = city,
                        AreaName = "Свердловский район"
                    },
                    new Area()
                    {
                        City = city,
                        AreaName = "Железнодорожный район"
                    },
                    new Area()
                    {
                        City = city,
                        AreaName = "Центральный район"
                    },
                    new Area()
                    {
                        City = city,
                        AreaName = "Кировский район"
                    },
                    new Area()
                    {
                        City = city,
                        AreaName = "Ленинский район"
                    },
                    new Area()
                    {
                        City = city,
                        AreaName = "Солонцы"
                    }
                };

                context.Areas.AddRange(areas);
            } else
            {
                areas = context.Areas.Take(7).ToList();
            }

            

            if (!context.UserAreas.Any())
            {

                foreach(var area in areas)
                {
                    foreach(var user in users)
                    {
                        user.UserAreas.Add(new UserArea()
                        {
                            Area = area
                        });
                    }
                }
            }

            List<Interest> interests;

            if (!context.Interests.Any())
            {
                interests = new List<Interest>()
                {
                    new Interest()
                    {
                        Name = "AC/DC"
                    },
                    new Interest()
                    {
                        Name = "Films"
                    },
                    new Interest()
                    {
                        Name = "Skatebourding"
                    },
                    new Interest()
                    {
                        Name = "Swiming"
                    },
                    new Interest()
                    {
                        Name = "GunsNRouses"
                    }
                };

                context.Interests.AddRange(interests);
            } else
            {
                interests = context.Interests.Take(5).ToList();
            }

            if (!context.UserInterests.Any())
            {
                foreach(var interest in interests)
                {
                    foreach(var user in users)
                    {
                        user.Interests.Add(new UserInterest() { Interest = interest.Name });
                    }
                }
            }

            if (!context.Messages.Any())
            {
                foreach (var userTo in users)
                {
                    foreach (var userFrom in users)
                    {
                        userFrom.MyMessages.Add(new Message()
                        {
                            ToUser = userTo,
                            Text = $"Hi, {userTo.FirstName}!",
                            Time = DateTime.Now
                        });
                        userFrom.MyMessages.Add(new Message()
                        {
                            ToUser = userTo,
                            Text = "How is it going?",
                            Time = DateTime.Now.Add(new TimeSpan(0,5,20))
                        });
                        userTo.MyMessages.Add(new Message()
                        {
                            ToUser = userFrom,
                            Text = "Hi, man!",
                            Time = DateTime.Now.Add(new TimeSpan(0, 7, 20))
                        });
                        userTo.MyMessages.Add(new Message()
                        {
                            ToUser = userFrom,
                            Text = "I'm just going by. How are you, bro? Whats up with your job interview? Did you pass it?",
                            Time = DateTime.Now.Add(new TimeSpan(0, 9, 20))
                        });
                        userFrom.MyMessages.Add(new Message()
                        {
                            ToUser = userTo,
                            Text = "Ofcourse i did it. Sorry bro i need to go see you",
                            Time = DateTime.Now.Add(new TimeSpan(0, 12, 20))
                        });
                        userTo.MyMessages.Add(new Message()
                        {
                            ToUser = userFrom,
                            Text = "Bye",
                            Time = DateTime.Now.Add(new TimeSpan(0, 13, 20))
                        });
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
