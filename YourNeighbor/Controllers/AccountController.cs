using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using YourNeighbor.Models;
using YourNeighbor.Models.Account;

namespace YourNeighbor.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
    }
}