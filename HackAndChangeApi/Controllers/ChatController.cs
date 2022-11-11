using HackAndChangeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HackAndChangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        HackAndChangeContext db;

        public ChatController(HackAndChangeContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Send(Message message)
        {
            if (message == null)
                return BadRequest();
            db.Messages.Add(message);
            await db.SaveChangesAsync();
            return Ok(message);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> History(int dialogId, int limit = 20)
        {
            if (limit < 1 || limit > 50)
                throw new ArgumentException();
            return await db.Messages
                .Where(m => m.DialogId == dialogId)
                .Take(limit)
                .ToListAsync();
        }

        //TODO do DialogMethod
        //[HttpGet]
        //public Task<IActionResult> Dialog()
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<Vidget>> Update(Vidget vidget)
        {
            if (vidget == null)
                return BadRequest();
            if (!db.Vidgets.Any(x => x.MessageId == vidget.MessageId))
                return NotFound();
            db.Update(vidget);
            await db.SaveChangesAsync();
            return Ok(vidget);
        }
    }
}
