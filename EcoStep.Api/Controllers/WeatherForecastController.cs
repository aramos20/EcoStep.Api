using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoStep.Infrastructure.Data;

namespace EcoStep.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ApplicationDbContext dbContext, ILogger<WeatherForecastController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }

        // Nueva acción para probar la conexión a la base de datos
        [HttpGet("test-db")]
        public async Task<IActionResult> TestDatabaseConnection()
        {
            try
            {
                // Intenta realizar una consulta básica en la base de datos
                var canConnect = await _dbContext.Database.CanConnectAsync();
                if (canConnect)
                {
                    return Ok("La conexión a la base de datos fue exitosa.");
                }
                else
                {
                    return StatusCode(500, "No se pudo conectar a la base de datos.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al probar la conexión a la base de datos.");
                return StatusCode(500, $"Error al conectar a la base de datos: {ex.Message}");
            }
        }
    }
}
