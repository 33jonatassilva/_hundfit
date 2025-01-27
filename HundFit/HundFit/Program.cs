using HundFit.Data;
using HundFit.Repositories;
using HundFit.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/swagger", () =>
    {
    
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();

