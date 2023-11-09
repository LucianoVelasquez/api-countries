using AutoMapper;
using Countries.Deserealizacion;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Countries.Controllers
{
    [ApiController]
    [Route("api/cargadatos")]
    public class IniciarDatosDbController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AplicationDbContext dbContext;
        private readonly IConfiguration configuration;

        public IniciarDatosDbController(IMapper mapper, AplicationDbContext dbContext,IConfiguration configuration)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        [HttpGet("iniciar")]
        public async Task<ActionResult<RootObject>> Get()
        {
            var path = configuration["Dbjson"];
            var jsonString = System.IO.File.ReadAllText(path);
            // Deserializa la cadena JSON a un objeto C#
            var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonString);

            for(int i = 0; i < rootObject.Countries.Count; i++)
            {
                var newCountry = new Entidades.Country
                {
                    Name = rootObject.Countries[i].Name.Common,
                    Tid = rootObject.Countries[i].Tld != null && rootObject.Countries[i].Tld.Count > 0 ?
                          rootObject.Countries[i].Tld[0] : "tld es null",
                    SubRegion = rootObject.Countries[i].Subregion,
                    Area = rootObject.Countries[i].Area,
                    Population = rootObject.Countries[i].Population,
                    Capitals = rootObject.Countries[i].Capital != null && rootObject.Countries[i].Capital.Count > 0 ?
                           rootObject.Countries[i].Capital[0] : "capital es null",
                    Continents = rootObject.Countries[i].Continents != null && rootObject.Countries[i].Continents.Count > 0 ?
                           rootObject.Countries[i].Continents[0] : "Continents es null",
                    Flags = rootObject.Countries[i].Flags.Png
                };

                if(!dbContext.Countries.Any(c => c.Name == newCountry.Name))
                {
                    dbContext.Add(newCountry);
                    dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"El registro {newCountry.Name} ya existe na la base de datos");
                }
            }

         return Ok("Datos cargados correctamente en la base de datos");
        }
    }
}