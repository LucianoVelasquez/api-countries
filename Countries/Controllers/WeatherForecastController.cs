using Countries.Deserealizacion;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Countries.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        public async Task<ActionResult<string>> Get()
        {
            var  path = @"C:\Users\lucia\Desktop\Peoyects\Countries\Countries\Deserealizacion\db.json";
            var jsonString = System.IO.File.ReadAllText(path);
            try
            {
                // Deserializa la cadena JSON a un objeto C#
                var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonString);
                var result = JsonConvert.SerializeObject(rootObject);

                return result;

            }
            catch (Exception ex)
            {
                return BadRequest($"Error al deserializar la cadena JSON: {ex.Message}");
            }


        }
    }
}