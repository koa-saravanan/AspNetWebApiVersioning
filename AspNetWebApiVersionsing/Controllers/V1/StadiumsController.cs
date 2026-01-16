using Asp.Versioning;

using AspNetWebApiVersionsing.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiVersionsing.Controllers.V1
{
    [ApiVersion("1.0", Deprecated = true)]
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
                    x.BuiltYear
                })
                .ToListAsync();

            return Ok(stadiums);
        }
    }
}
