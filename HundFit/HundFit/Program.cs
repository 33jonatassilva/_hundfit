using HundFit.Data;
using HundFit.Repositories;
using HundFit.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped(IExerciseRepository, ExerciseRepository);
builder.Services.AddScoped(IPaymentRepository, PaymentRepository);
builder.Services.AddScoped(IPhysicalAssessmentRepository, PhysicalAssessmentRepository);
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped(IStudentRepository, StudentRepository);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();

