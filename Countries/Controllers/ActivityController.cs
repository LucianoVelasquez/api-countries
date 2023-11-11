using AutoMapper;
using Countries.DTOS;
using Countries.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countries.Controllers
{
    [ApiController]
    [Route("api/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly AplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ActivityController(AplicationDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> Post([FromBody] CreacionActivityDTO creacionActivityDTO)
        {
            if(creacionActivityDTO.CountryIds == null) { return BadRequest("Debes colocar un id"); }

            var countryIds = await dbContext.Countries
                .Where(c => creacionActivityDTO.CountryIds.Contains(c.Id))
                .Select(x => x.Id).ToListAsync();

            if(creacionActivityDTO.CountryIds.Count != countryIds.Count) { return BadRequest("Algun id no existe"); }

            var entidad = mapper.Map<Activity>(creacionActivityDTO);

            dbContext.Add(entidad);
            await dbContext.SaveChangesAsync();

            var dto = mapper.Map<ActivityDTO>(entidad);

            return Ok(dto);
        }


    }
}
