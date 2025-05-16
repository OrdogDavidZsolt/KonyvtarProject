using KonyvtarAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KonyvekController
{
    [ApiController]
    [Route("konyvek")]
    public class KonyvekController : ControllerBase
    {
        private readonly KonyvtarDBContext _konyvtarDbContext;

        public KonyvekController(KonyvtarDBContext konyvtarDbContext)
        {
            _konyvtarDbContext = konyvtarDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Konyvek konyv)
        {
            var existingKonyv = await _konyvtarDbContext.Konyvek.FindAsync(konyv.LeltariSzam);

            if (existingKonyv is not null)
            {
                return Conflict();
            }

            _konyvtarDbContext.Konyvek.Add(konyv);
            await _konyvtarDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{leltariSzam}")]
        public async Task<IActionResult> Delete(int leltariSzam)
        {
            var existingKonyv = await _konyvtarDbContext.Konyvek.FindAsync(leltariSzam);

            if (existingKonyv is null)
            {
                return NotFound();
            }

            _konyvtarDbContext.Konyvek.Remove(existingKonyv);
            await _konyvtarDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Konyvek>>> GetAll()
        {
            var konyvek = await _konyvtarDbContext.Konyvek.ToListAsync();
            return Ok(konyvek);
        }

        [HttpGet("{leltariSzam}")]
        public async Task<ActionResult<Konyvek>> Get(int leltariSzam)
        {
            var konyv = await _konyvtarDbContext.Konyvek.FindAsync(leltariSzam);

            if (konyv is null)
            {
                return NotFound();
            }

            return Ok(konyv);
        }

        [HttpPut("{leltariSzam}")]
        public async Task<IActionResult> Update(int leltariSzam, [FromBody] Konyvek konyv)
        {
            if (leltariSzam != konyv.LeltariSzam)
            {
                return BadRequest();
            }

            var oldKonyv = await _konyvtarDbContext.Konyvek.FindAsync(leltariSzam);

            if (oldKonyv is null)
            {
                return NotFound();
            }

            oldKonyv.LeltariSzam = konyv.LeltariSzam;
            oldKonyv.Szerzo = konyv.Szerzo;
            oldKonyv.KiadasEve = konyv.KiadasEve;
            oldKonyv.Kiado = konyv.Kiado;
            oldKonyv.Cim = konyv.Cim;

            _konyvtarDbContext.Konyvek.Update(oldKonyv);
            await _konyvtarDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
