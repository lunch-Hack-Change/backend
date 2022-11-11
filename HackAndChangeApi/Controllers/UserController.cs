﻿using HackAndChangeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackAndChangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private HackAndChangeContext db;

        public UserController(HackAndChangeContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Info(int userId)
        {
            var user = db.Users.Find(userId);
            if (user == null)
                return NotFound();
            var newUser = new User
            {
                UserId = user.UserId,
                Avatar = user.Avatar,
                Surname = user.Surname,
                Name = user.Name,
                MiddleName = user.MiddleName
            };
            return Ok(newUser);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Info(User user)
        {
            if (user == null)
                return BadRequest();
            if (!db.Users.Any(x => x.UserId == user.UserId))
                return NotFound();
            db.Users.Update(user);
            db.SaveChangesAsync();
            return Ok(User);
        }
    }
}
