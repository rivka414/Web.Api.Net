using Microsoft.EntityFrameworkCore;
using Clean.Core.Data;
using Clean.Core.Repositories;
using Clean.Data.Repository;
using Clean.Service.Services;
using TipatCholAPI.Mapping;

var builder = WebApplication.CreateBuilder(args);

// 1. הגדרת מסד הנתונים - משיכת ה-Connection String מה-appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        // מאפשר למערכת לנסות להתחבר שוב במקרה של ניתוק רגעית
        sqlOptions.EnableRetryOnFailure();
    }));

// 2. רישום ה-Repositories
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IBabyRepository, BabyRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();

// 3. רישום ה-Repository Manager
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

// 4. רישום ה-Services
builder.Services.AddScoped<BabyService>();
builder.Services.AddScoped<NurseService>();
builder.Services.AddScoped<AppointmentService>();

// הגדרות בסיסיות של ה-API
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

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