using Countries.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countries.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController :ControllerBase
    {
        private readonly AplicationDbContext dbContext;

        public CountriesController(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountry()
        {
            var countries = await dbContext.Countries.ToListAsync();

            if(countries.Count == 0) { BadRequest(); }

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryId(string id)
        {
            id = "." + id;
            var country = await dbContext.Countries.SingleOrDefaultAsync(c => c.Tid.ToLower() == id.ToLower());

            if(country == null) { return BadRequest("No se encontro pais con ese Id"); }

            return Ok(country);
        }

        [HttpGet("country")]
        public async Task<ActionResult<Country>> GetCountryName([FromQuery] string name)
        { 
            
            var country = await dbContext.Countries.SingleOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (country == null) { return BadRequest("No se encontro pais con ese Name"); }

            return Ok(country);
        }
    }
}
