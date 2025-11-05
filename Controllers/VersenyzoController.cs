using Microsoft.AspNetCore.Mvc;
using EuroskillsAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EuroskillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersenyzoController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public VersenyzoController(EuroskillsContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Versenyzok
                .Join(_context.Szakmak,
                      v => v.SzakmaId,
                      s => s.Id,
                      (v, s) => new { v, s })
                .Join(_context.Orszagok,
                      vs => vs.v.OrszagId,
                      o => o.Id,
                      (vs, o) => new
                      {
                          vs.v.Id,
                          vs.v.Nev,
                          Szakma = vs.s.SzakmaNev,
                          Orszag = o.OrszagNev,
                          vs.v.Pont
                      })
                .OrderByDescending(x => x.Pont)
                .ToListAsync();

            return Ok(result);
        }
    }
}
