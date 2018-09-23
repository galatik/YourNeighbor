using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using YourNeighbor.Models;
using YourNeighbor.Models.Account;
using YourNeighbor.Data;

namespace YourNeighbor.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly ApplicationDbContext _appDbContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext applicationDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appDbContext = applicationDbContext;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.Login,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Birthday = model.Birthday
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, model.RememberMe);

                    return Ok(user.UserName);
                } else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Login);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, user.AccessFailedCount > 14);

                    if (result.IsLockedOut)
                    {
                        user.LockoutEnabled = true;

                        user.LockoutEnd = DateTimeOffset.Now.Add(new TimeSpan(2, 0, 0));

                        await _userManager.UpdateAsync(user);
                    }

                    if (result.Succeeded)
                    {
                        return Ok(user.UserName);
                    }
                }

                ModelState.AddModelError("", "Uncorrect login or password");
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        // TODO: Check should _appDbContext be saved or not
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] EditModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await (from u in _appDbContext.Users
                            where u.UserName == HttpContext.User.Identity.Name
                            select u).Include(u => u.UserAreas).Include(u => u.Interests)
                           .FirstOrDefaultAsync();
                    
                if(user != null)
                {
                    if (!string.IsNullOrEmpty(model.Login))
                    {
                        user.UserName = model.Login;
                    }

                    if (!string.IsNullOrEmpty(model.FirstName))
                    {
                        user.FirstName = model.FirstName;
                    }

                    if (!string.IsNullOrEmpty(model.LastName))
                    {
                        user.LastName = model.LastName;
                    }

                    if (!string.IsNullOrEmpty(model.AboutMe))
                    {
                        user.AboutMe = model.AboutMe;
                    }

                    if (model.SocialStatus != null)
                    {
                        user.SocialStatus = (SocialStatus) model.SocialStatus;
                    }

                    if (model.Bithday != null)
                    {
                        user.Birthday = model.Bithday;
                    }

                    if (model.MinCountOfRooms != null)
                    {
                        user.MinCountOfRooms = (int) model.MinCountOfRooms;
                    }

                    if (model.MaxCountOfRooms != null)
                    {
                        user.MaxCountOfRooms = (int) model.MaxCountOfRooms;
                    }

                    if (model.MaxCost != null)
                    {
                        user.MaxCost = (int) model.MaxCost;
                    }

                    if (model.StartCost != null)
                    {
                        user.StartCost = (int) model.StartCost;
                    }

                    if (model.Smoking != null)
                    {
                        user.Smoking = (bool) model.Smoking;
                    }

                    if (model.HasPets != null)
                    {
                        user.HasPets = (bool) model.HasPets;
                    }

                    if (model.Areas != null)
                    {
                        foreach(var area in model.Areas)
                        {
                            if (!user.UserAreas.Any(ua => ua.AreaId == area.Id))
                            {
                                user.UserAreas.Add(new UserArea()
                                {
                                    UserId = user.Id,
                                    AreaId = area.Id
                                });
                            }   
                        }
                    }

                    if (model.Interests != null)
                    {
                        foreach (var interest in model.Interests)
                        {
                            if (!user.Interests.Any(i => i.Interest == interest.Name))
                            {
                                user.Interests.Add(new UserInterest()
                                {
                                    UserId = user.Id,
                                    Interest = interest.Name
                                });
                            }
                        }
                    }

                    await _userManager.UpdateAsync(user);

                    return Ok("Changes have been saved");
                }
            }

            return BadRequest(ModelState);
        }

    }
}