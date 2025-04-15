using KonyvtarAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolcsonzesController
{
    [ApiController]
    [Route("kolcsonzes")]
    public class KolcsonzesController : ControllerBase
    {
        private readonly KonyvtarDBContext _konyvtarDBContext;

        public KolcsonzesController(KonyvtarDBContext konyvtarDBContext)
        {
            _konyvtarDBContext = konyvtarDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Kolcsonzes kolcsonzes)
        {
            var existingKolcsonzes = await _konyvtarDBContext.Kolcsonzesek.FindAsync(kolcsonzes.LeltariSzam);

            if (existingKolcsonzes is not null)
            {
                return Conflict();
            }

            _konyvtarDBContext.Kolcsonzesek.Add(kolcsonzes);
            await _konyvtarDBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int LeltariSzam)
        {
            var existingKolcsonzes = await _konyvtarDBContext.Kolcsonzesek.FindAsync(LeltariSzam);

            if (existingKolcsonzes is null)
            {
                return NotFound();
            }

            _konyvtarDBContext.Kolcsonzesek.Remove(existingKolcsonzes);
            await _konyvtarDBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Kolcsonzes>>> GetAll()
        {
            var kolcsonzes = await _konyvtarDBContext.Kolcsonzesek.ToListAsync();
            return Ok(kolcsonzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kolcsonzes>> Get(int id)
        {
            var kolcsonzes = await _konyvtarDBContext.Kolcsonzesek.FindAsync(id);

            if (kolcsonzes is null)
            {
                return NotFound();
            }

            return Ok(kolcsonzes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int LeltariSzam, [FromBody] Kolcsonzes kolcsonzes)
        {
            if (LeltariSzam != kolcsonzes.LeltariSzam)
            {
                return BadRequest();
            }

            var oldKolcsonzes = await _konyvtarDBContext.Kolcsonzesek.FindAsync(LeltariSzam);

            if (oldKolcsonzes is null)
            {
                return NotFound();
            }

            oldKolcsonzes.OlvasoSzam = kolcsonzes.OlvasoSzam;
            oldKolcsonzes.LeltariSzam = kolcsonzes.LeltariSzam;
            oldKolcsonzes.KolcsonzesIdeje = kolcsonzes.KolcsonzesIdeje;
            oldKolcsonzes.VisszahozasHatarido = kolcsonzes.VisszahozasHatarido;

            _konyvtarDBContext.Kolcsonzesek.Update(oldKolcsonzes);
            await _konyvtarDBContext.SaveChangesAsync();

            return Ok();
        }
    }
}
