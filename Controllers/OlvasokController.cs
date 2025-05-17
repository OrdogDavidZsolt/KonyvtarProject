using KonyvtarAPI;
using KonyvtarAPI.KonyvtarShared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OlvasokController
{
    [ApiController]
    [Route("olvasok")]
    public class OlvasokController : ControllerBase
    {
        private readonly KonyvtarDBContext _konyvtarDbContext;

        public OlvasokController(KonyvtarDBContext konyvtarDbContext)
        {
            _konyvtarDbContext = konyvtarDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Olvasok olvaso)
        {
            var existingOlvaso = await _konyvtarDbContext.Olvasok.FindAsync(olvaso.OlvasoSzam);

            if (existingOlvaso is not null)
            {
                return Conflict();
            }

            _konyvtarDbContext.Olvasok.Add(olvaso);
            await _konyvtarDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{olvasoSzam}")]
        public async Task<IActionResult> Delete(int olvasoSzam)
        {
            var existingOlvaso = await _konyvtarDbContext.Olvasok.FindAsync(olvasoSzam);

            if (existingOlvaso is null)
            {
                return NotFound();
            }

            _konyvtarDbContext.Olvasok.Remove(existingOlvaso);
            await _konyvtarDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Olvasok>>> GetAll()
        {
            var olvasok = await _konyvtarDbContext.Olvasok.ToListAsync();
            return Ok(olvasok);
        }

        [HttpGet("{olvasoSzam}")]
        public async Task<ActionResult<Olvasok>> Get(int olvasoSzam)
        {
            var olvaso = await _konyvtarDbContext.Olvasok.FindAsync(olvasoSzam);

            if (olvaso is null)
            {
                return NotFound();
            }

            return Ok(olvaso);
        }

        [HttpPut("{olvasoSzam}")]
        public async Task<IActionResult> Update(int olvasoSzam, [FromBody] Olvasok olvaso)
        {
            if (olvasoSzam != olvaso.OlvasoSzam)
            {
                return BadRequest();
            }

            var oldOlvaso = await _konyvtarDbContext.Olvasok.FindAsync(olvasoSzam);

            if (oldOlvaso is null)
            {
                return NotFound();
            }

            oldOlvaso.OlvasoSzam = olvaso.OlvasoSzam;
            oldOlvaso.SzuletesiDatum = olvaso.SzuletesiDatum;
            oldOlvaso.Lakcim = olvaso.Lakcim;
            oldOlvaso.OlvasoNev = olvaso.OlvasoNev;

            _konyvtarDbContext.Olvasok.Update(oldOlvaso);
            await _konyvtarDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}