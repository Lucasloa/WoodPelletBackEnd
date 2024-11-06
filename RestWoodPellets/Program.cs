using WoodPelletsLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<WoodPelletRepository>(new WoodPelletRepository());
// Added Cors opg 7
builder.Services.AddCors(Options => { Options.AddPolicy(name: "AllowAll", policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
// Added cors opg 7
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
