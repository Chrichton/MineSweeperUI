using WebApplication1.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<IEnumerable<MineSweeperField>> MineSweeperFields()
        {
            return Enumerable.Range(0, 4)
                .Select(row => Enumerable.Range(0, 3)
                .Select(col => new MineSweeperField
                {
                    Column = col,
                    Row = row,
                    Value = GetRandomFieldValue()
                }));
        }

        private string GetRandomFieldValue()
        {
            var rng = new Random();
            var value = rng.Next(0, 8);
            return value == 0 ? " " : Convert.ToString(value);
        }
    }
}
