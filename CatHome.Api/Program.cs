using CatHome.Domain.Repositories;
using CatHome.Domain.Services;
using CatHome.Domain.Services.Interfaces;
using CatHome.Infrastructure.Context;
using CatHome.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICatService, CatService>();
builder.Services.AddTransient<IAdoptionApplicationService, AdoptionApplicationService>();
builder.Services.AddTransient<IAdoptionApplicationRepository, AdoptionApplicationRepository>();
builder.Services.AddTransient<ICatRepository, CatRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<JsonContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Remove before deploy
app.UseCors(builder =>
{
    builder.WithOrigins("http://127.0.0.1:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
