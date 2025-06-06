using KonyvtarAPI;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSerilog(
    options => options
        .MinimumLevel.Information()
        .WriteTo.Console()
);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<KonyvtarDBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IKolcsonzesCRUD, KolcsonzesService>();
builder.Services.AddSingleton<IKonyvekCRUD, KonyvekService>();
builder.Services.AddSingleton<IOlvasokCRUD, OlvasokService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

