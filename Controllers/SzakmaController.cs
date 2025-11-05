using Microsoft.AspNetCore.Mvc;
using EuroskillsAPI.Data;
using EuroskillsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EuroskillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SzakmaController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public SzakmaController(EuroskillsContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Szakma>> GetAll()
        {
            return await _context.Szakmak.ToListAsync();
        }
    }
}
