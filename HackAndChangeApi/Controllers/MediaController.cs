using HackAndChangeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAndChangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        HackAndChangeContext db;
        public MediaController(HackAndChangeContext context)
        {
            db = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Media media)
        {
            if (media == null)
                return BadRequest();
            await db.Media.AddAsync(media);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Media>> Get() => await db.Media.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Media>> Get(int id)
        {
            var media = await db.Media.FirstOrDefaultAsync(x => x.MediaId == id);
            if (media == null)
                return NotFound();
            return media;
        }

        [HttpPut]
        public async Task<ActionResult<Media>> Update(Media media)
        {
            if (media == null)
                return BadRequest();
            if (!db.Media.Any(x => x.MediaId == media.MediaId))
                return NotFound();
            db.Update(media);
            await db.SaveChangesAsync();
            return Ok(media);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Media>> Delete(int id)
        {
            var media = db.Media.FirstOrDefault(x => x.MediaId == id);
            if (media == null)
                return NotFound();
            db.Media.Remove(media);
            await db.SaveChangesAsync();
            return Ok(media);
        }

    }
}
