using Asp.Versioning;

using AspNetWebApiVersionsing.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiVersionsing.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StadiumsController(
        LeagueManagerDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStadiums()
        {
            var stadiums = await dbContext.Stadiums
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.BuiltYear,
                    x.PitchLength,
                    x.PitchWidth,
                    x.City
                })
                .ToListAsync();

            return Ok(stadiums);
        }
    }
}
