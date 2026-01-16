using Asp.Versioning;

using AspNetWebApiVersionsing.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;

    //options.ApiVersionReader = new QueryStringApiVersionReader("v");
    //options.ApiVersionReader = new UrlSegmentApiVersionReader();
    //options.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");

    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));


}).AddMvc();

builder.Services.AddDbContext<LeagueManagerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


