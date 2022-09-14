using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoForDI31.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace demoForDI31.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOrderService orderService)
        {
            _logger = logger;
        }

        //public WeatherForecastController(ILogger<WeatherForecastController> logger, IGenericService<IOrderService> genericService)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetServices")]
        public int GetServices
        (
            [FromServices] IMySingletonService singleton1,
            [FromServices] IMySingletonService singleton2,
            [FromServices] IMyScopedService scoped1,
            [FromServices] IMyScopedService scoped2,
            [FromServices] IMyTransientService transient1,
            [FromServices] IMyTransientService transient2
        )
        {
            Console.WriteLine($"请求开始");

            Console.WriteLine($"singleton1:{singleton1.GetHashCode()}");
            Console.WriteLine($"singleton2:{singleton2.GetHashCode()}");

            Console.WriteLine($"scoped1:{scoped1.GetHashCode()}");
            Console.WriteLine($"scoped2:{scoped2.GetHashCode()}");

            Console.WriteLine($"transient1:{transient1.GetHashCode()}");
            Console.WriteLine($"transient2:{transient2.GetHashCode()}");

            Console.WriteLine($"请求结束");
            return 1;
        }

        [HttpGet("GetServiceList")] 
        public int GetServiceList([FromServices] IEnumerable<IOrderService> orderServices) 
        {
            foreach (var orderService in orderServices)
            {
                Console.WriteLine($"{orderService}:{orderService.GetHashCode()}");
            }

            return 1;
        }

        [HttpGet("GetService")]
        public int GetService([FromServices]IOrderService orderService)
        {
            Console.WriteLine($"{orderService}:{orderService.GetHashCode()}");
            return 1;
        }
    }
}
