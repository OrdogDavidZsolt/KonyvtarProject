using KonyvtarAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KonyvekController
{
    [ApiController]
    [Route("konyvek")]
    public class KonyvekController : ControllerBase
    {
        private readonly KonyvtarDBContext _konyvtarDBContext;

        public KonyvekController(KonyvtarDBContext konyvtarDBContext)
        {
            _konyvtarDBContext = konyvtarDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Konyvek konyv)
        {
            var existingKonyv = await _konyvtarDBContext.Konyvek.FindAsync(konyv.LeltariSzam);

            if (existingKonyv is not null)
            {
                return Conflict();
            }

            _konyvtarDBContext.Konyvek.Add(konyv);
            await _konyvtarDBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{LeltariSzam}")]
        public async Task<IActionResult> Delete(int LeltariSzam)
        {
            var existingKonyv = await _konyvtarDBContext.Konyvek.FindAsync(LeltariSzam);

            if (existingKonyv is null)
            {
                return NotFound();
            }

            _konyvtarDBContext.Konyvek.Remove(existingKonyv);
            await _konyvtarDBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Konyvek>>> GetAll()
        {
            var konyvek = await _konyvtarDBContext.Konyvek.ToListAsync();
            return Ok(konyvek);
        }

        [HttpGet("{LeltariSzam}")]
        public async Task<ActionResult<Konyvek>> Get(int LeltariSzam)
        {
            var konyv = await _konyvtarDBContext.Konyvek.FindAsync(LeltariSzam);

            if (konyv is null)
            {
                return NotFound();
            }

            return Ok(konyv);
        }

        [HttpPut("{LeltariSzam}")]
        public async Task<IActionResult> Update(int LeltariSzam, [FromBody] Konyvek konyv)
        {
            if (LeltariSzam != konyv.LeltariSzam)
            {
                return BadRequest();
            }

            var oldKonyv = await _konyvtarDBContext.Konyvek.FindAsync(LeltariSzam);

            if (oldKonyv is null)
            {
                return NotFound();
            }

            oldKonyv.LeltariSzam = konyv.LeltariSzam;
            oldKonyv.Szerzo = konyv.Szerzo;
            oldKonyv.KiadasEve = konyv.KiadasEve;
            oldKonyv.Kiado = konyv.Kiado;
            oldKonyv.Cim = konyv.Cim;

            _konyvtarDBContext.Konyvek.Update(oldKonyv);
            await _konyvtarDBContext.SaveChangesAsync();

            return Ok();
        }
    }
}
