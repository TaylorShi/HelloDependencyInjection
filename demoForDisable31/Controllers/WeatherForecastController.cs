using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoForDisable31.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demoForDisable31.Controllers
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

        //[HttpGet]
        //public int Get([FromServices] IOrderService orderService1, [FromServices] IOrderService orderService2)
        //{
        //    Console.WriteLine($"子容器开始");

        //    using (IServiceScope scope = HttpContext.RequestServices.CreateScope())
        //    {
        //        var service1 = scope.ServiceProvider.GetService<IOrderService>();
        //        var service2 = scope.ServiceProvider.GetService<IOrderService>();
        //    }

        //    Console.WriteLine($"子容器结束");

        //    Console.WriteLine($"接口请求处理结束");
        //    return 1;
        //}

        [HttpGet]
        public int Get
        (
            [FromServices] IOrderService orderService1,
            [FromServices] IOrderService orderService2,
            [FromServices] IHostApplicationLifetime hostApplicationLifetime,
            [FromQuery] bool stop = false
        )
        {
            Console.WriteLine($"接口请求处理结束");
            if (stop)
            {
                hostApplicationLifetime.StopApplication();
            }
            return 1;
        }

        //[HttpGet]
        //public int Get
        //(
        //    [FromServices] IHostApplicationLifetime hostApplicationLifetime,
        //    [FromQuery] bool stop = false
        //)
        //{
        //    Console.WriteLine($"接口请求处理结束");
        //    if (stop)
        //    {
        //        hostApplicationLifetime.StopApplication();
        //    }
        //    return 1;
        //}
    }
}
