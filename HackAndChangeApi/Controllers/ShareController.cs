using HackAndChangeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HackAndChangeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        HackAndChangeContext db;
        public ShareController(HackAndChangeContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Share share)
        {
            if (share == null)
                return BadRequest();
            await db.Shares.AddAsync(share);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Share>> Get() => await db.Shares.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Share>> Get(int id)
        {
            var share = await db.Shares.FirstOrDefaultAsync(x => x.ShareId == id);
            if (share == null)
                return NotFound();
            return share;
        }

        [HttpPut]
        public async Task<ActionResult<Share>> Update(Share share)
        {
            if (share == null)
                return BadRequest();
            if (!db.Shares.Any(x => x.ShareId == share.ShareId))
                return NotFound();
            db.Update(share);
            await db.SaveChangesAsync();
            return Ok(share);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Share>> Delete(int id)
        {
            var share = db.Shares.FirstOrDefault(x => x.ShareId == id);
            if (share == null)
                return NotFound();
            db.Shares.Remove(share);
            await db.SaveChangesAsync();
            return Ok(share);
        }
    }
}
