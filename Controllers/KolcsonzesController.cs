using KonyvtarAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolcsonzesController
{
    [ApiController]
    [Route("kolcsonzes")]
    public class KolcsonzesController : ControllerBase
    {
        private readonly KonyvtarDBContext _konyvtarDbContext;

        public KolcsonzesController(KonyvtarDBContext konyvtarDbContext)
        {
            _konyvtarDbContext = konyvtarDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Kolcsonzes kolcsonzes)
        {
            var existingKolcsonzes = await _konyvtarDbContext.Kolcsonzesek.FindAsync(kolcsonzes.LeltariSzam);

            if (existingKolcsonzes is not null)
            {
                return Conflict();
            }

            _konyvtarDbContext.Kolcsonzesek.Add(kolcsonzes);
            await _konyvtarDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{kolcsonzesSzam}")]
        public async Task<IActionResult> Delete(int kolcsonzesSzam)
        {
            var existingKolcsonzes = await _konyvtarDbContext.Kolcsonzesek.FindAsync(kolcsonzesSzam);

            if (existingKolcsonzes is null)
            {
                return NotFound();
            }

            _konyvtarDbContext.Kolcsonzesek.Remove(existingKolcsonzes);
            await _konyvtarDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Kolcsonzes>>> GetAll()
        {
            var kolcsonzes = await _konyvtarDbContext.Kolcsonzesek.ToListAsync();
            return Ok(kolcsonzes);
        }

        [HttpGet("{kolcsonzesSzam}")]
        public async Task<ActionResult<Kolcsonzes>> Get(int kolcsonzesSzam)
        {
            var kolcsonzes = await _konyvtarDbContext.Kolcsonzesek.FindAsync(kolcsonzesSzam);

            if (kolcsonzes is null)
            {
                return NotFound();
            }

            return Ok(kolcsonzes);
        }

        [HttpPut("{kolcsonzesSzam}")]
        public async Task<IActionResult> Update(int kolcsonzesSzam, [FromBody] Kolcsonzes kolcsonzes)
        {
            if (kolcsonzesSzam != kolcsonzes.LeltariSzam)
            {
                return BadRequest();
            }

            var oldKolcsonzes = await _konyvtarDbContext.Kolcsonzesek.FindAsync(kolcsonzesSzam);

            if (oldKolcsonzes is null)
            {
                return NotFound();
            }

            oldKolcsonzes.OlvasoSzam = kolcsonzes.OlvasoSzam;
            oldKolcsonzes.LeltariSzam = kolcsonzes.LeltariSzam;
            oldKolcsonzes.KolcsonzesIdeje = kolcsonzes.KolcsonzesIdeje;
            oldKolcsonzes.VisszahozasHatarido = kolcsonzes.VisszahozasHatarido;

            _konyvtarDbContext.Kolcsonzesek.Update(oldKolcsonzes);
            await _konyvtarDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
