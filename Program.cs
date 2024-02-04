using API;
using API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


/*
builder.Services.AddRazorPages();
//get the configuration properties
var cfg = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

*/

builder.Services.AddDbContext<DataContext>(opt => 
{
     // la chaine de connection 
      opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

});


var app = builder.Build();


app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();