using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using YourNeighbor.Data;
using YourNeighbor.Models;

namespace YourNeighbor.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DialogsController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;

        private readonly UserManager<User> _userManager;

        public DialogsController(ApplicationDbContext applicationContext, UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        [HttpGet("{pageNumber=0}")]
        public async Task<IActionResult> GetDialogs(int pageNumber)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            var userDialogsQuery = from dialog in _applicationContext.Dialogs
                          where dialog.LastMessageUserFromId == user.Id || dialog.LastMessageUserToId == user.Id
                          select dialog;

            int countOfUserDialogs = userDialogsQuery.Count();

            if (pageNumber * 10 > countOfUserDialogs)
            {
                return BadRequest("pageNumber too big");
            }

            var userDialogs = (from dialog in userDialogsQuery
                              select new
                              {
                                  dialog.LastMessageText,
                                  dialog.LastMessageTime,
                                  LastMessageToUser = (from u in _applicationContext.Users
                                                       where u.Id == dialog.LastMessageUserToId
                                                       select new { u.UserName, u.Id }).FirstOrDefault(),
                                  LastMessageFromUser = (from u in _applicationContext.Users
                                                         where u.Id == dialog.LastMessageUserFromId
                                                         select new { u.UserName, u.Id }).FirstOrDefault()
                              }).Skip(pageNumber * 10).Take(10).ToList();


            return Ok(userDialogs);
        }
    }
}