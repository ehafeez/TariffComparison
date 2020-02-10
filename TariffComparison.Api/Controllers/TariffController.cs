using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffComparison.Business;

namespace TariffComparison.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TariffController : Controller
    {
        /// <summary>
        /// Get Tariffs w.r.t consumption
        /// </summary>
        /// <param name="consumption">Consumption in KW</param>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery(Name = "consumption")] double consumption)
        {
            try
            {
                var availableTariffs = new AvailableTariff();
                var result = availableTariffs.GetAllTariffs()
                    .Select(i => new {i.Name, AnnualCost = i.CostCalulation(consumption)})
                    .Distinct()
                    .OrderBy(i => i.AnnualCost)
                    .ToList();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Can't get the tariff {e.Message}");
            }
        }
    }
}