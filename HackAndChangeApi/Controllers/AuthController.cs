﻿using HackAndChangeApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HackAndChangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private HackAndChangeContext db;
        public AuthController(HackAndChangeContext context)
        {
            db = context;
        }
        private bool CheckUser(string login, string password, out User user)
        {
            
            user = db.Users.FirstOrDefault(x => login == x.Login && password == x.Password);
            if (user == null)
                return false;
            return true;
        }

        [HttpPost]
        public async Task<ActionResult<AuthUser>> Auth(string login, string password)
        {

            User user;
            var authUser = new AuthUser();
            if (CheckUser(login, password, out user))
            {
                authUser.UserId = user.UserId;
                authUser.Login = user.Login;
                authUser.JwtTocken = JwtManager.GenerateToken(authUser.Login);
                authUser.Role = user.Role;
                db.Add(authUser);
                await db.SaveChangesAsync();
            }
            else
                return NotFound();
            return Ok(authUser);
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult<User>> Registration(string login, string password)
        {
            var user = new User { UserId = db.Users.Count() + 1, Login = login, Password = password};
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(User);
        }
    }
}
