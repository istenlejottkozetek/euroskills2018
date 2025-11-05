using Microsoft.AspNetCore.Mvc;
using EuroskillsAPI.Data;
using EuroskillsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EuroskillsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrszagController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public OrszagController(EuroskillsContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Orszag>> GetAll()
        {
            return await _context.Orszagok.ToListAsync();
        }
    }
}
