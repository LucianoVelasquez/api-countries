using AutoMapper;
using Countries.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countries.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CountriesController(AplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryDTO>>> GetAllCountry()
        {
            var countries = await dbContext.Countries.ToListAsync();

            if (countries.Count == 0) { BadRequest(); }

            var dto = mapper.Map<List<CountryDTO>>(countries);

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CountryDTO>>> GetCountryId(string id)
        {
            id = "." + id;
            var countries = await dbContext.Countries
                .Where(c => c.Tid.ToLower().StartsWith(id.ToLower()))
                .ToListAsync();

            if (countries.Count == 0) { return NotFound("No se encontro pais con ese Id"); }

            var dto = mapper.Map<List<CountryDTO>>(countries);

            return Ok(dto);
        }

        [HttpGet("country")]
        public async Task<ActionResult<List<CountryDTO>>> GetCountryName([FromQuery] string name)
        {
            if(name == null) { return BadRequest("Nombre incorrecto"); }

            var countries = await dbContext.Countries
                   .Where(c => c.Name.ToLower().StartsWith(name.ToLower()))
                   .ToListAsync();

            if (countries.Count == 0) { return NotFound("No se encontro pais con ese Name"); }

            var dto = mapper.Map<List<CountryDTO>>(countries);

            return Ok(dto);
        }
    }
}
