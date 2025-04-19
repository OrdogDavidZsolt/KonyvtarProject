using KonyvtarAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OlvasokController
{
    [ApiController]
    [Route("olvasok")]
    public class OlvasokController : ControllerBase
    {
        private readonly KonyvtarDBContext _konyvtarDBContext;

        public OlvasokController(KonyvtarDBContext konyvtarDBContext)
        {
            _konyvtarDBContext = konyvtarDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Olvasok olvaso)
        {
            var existingOlvaso = await _konyvtarDBContext.Olvasok.FindAsync(olvaso.OlvasoSzam);

            if (existingOlvaso is not null)
            {
                return Conflict();
            }

            _konyvtarDBContext.Olvasok.Add(olvaso);
            await _konyvtarDBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{OlvasoSzam}")]
        public async Task<IActionResult> Delete(int OlvasoSzam)
        {
            var existingOlvaso = await _konyvtarDBContext.Olvasok.FindAsync(OlvasoSzam);

            if (existingOlvaso is null)
            {
                return NotFound();
            }

            _konyvtarDBContext.Olvasok.Remove(existingOlvaso);
            await _konyvtarDBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Olvasok>>> GetAll()
        {
            var olvasok = await _konyvtarDBContext.Olvasok.ToListAsync();
            return Ok(olvasok);
        }

        [HttpGet("{OlvasoSzam}")]
        public async Task<ActionResult<Olvasok>> Get(int OlvasoSzam)
        {
            var olvaso = await _konyvtarDBContext.Olvasok.FindAsync(OlvasoSzam);

            if (olvaso is null)
            {
                return NotFound();
            }

            return Ok(olvaso);
        }

        [HttpPut("{OlvasoSzam}")]
        public async Task<IActionResult> Update(int OlvasoSzam, [FromBody] Olvasok olvaso)
        {
            if (OlvasoSzam != olvaso.OlvasoSzam)
            {
                return BadRequest();
            }

            var oldOlvaso = await _konyvtarDBContext.Olvasok.FindAsync(OlvasoSzam);

            if (oldOlvaso is null)
            {
                return NotFound();
            }

            oldOlvaso.OlvasoSzam = olvaso.OlvasoSzam;
            oldOlvaso.SzuletesiDatum = olvaso.SzuletesiDatum;
            oldOlvaso.Lakcim = olvaso.Lakcim;
            oldOlvaso.OlvasoNev = olvaso.OlvasoNev;

            _konyvtarDBContext.Olvasok.Update(oldOlvaso);
            await _konyvtarDBContext.SaveChangesAsync();

            return Ok();
        }
    }
}