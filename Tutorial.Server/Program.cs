using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Tutorial.Domain.IRepositories;
using Tutorial.Domain.IServices;
using Tutorial.Repositories.Data;
using Tutorial.Repositories.RepositoryImpl;
using Tutorial.Service.ServiceImpl;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<ISubTopicsService, SubTopicsService>();
builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<ISubTopicRepository, SubTopicRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();

builder.Services.AddControllers();

//configure serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tutorial API",
        Version = "v1"
    });
});
//allow Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


// Add DbContext

builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tutorial API v1");
        c.RoutePrefix = string.Empty; // Swagger opens at root "/"
    });
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


try
{
    Log.Information("Tutorial Service Running");
    app.Run();

}
catch(Exception ex)
{
    Log.Fatal(ex, "Tutorial Service Failed to Start");
}
finally
{
    Log.CloseAndFlush();
}





