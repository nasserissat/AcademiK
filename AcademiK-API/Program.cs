using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.Data.Repositories;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AcademiKContext>(options => options.UseMySql("name=AcademiKConnection", new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AcademiKContext>();
    context.Database.Migrate();

}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseCors("AllowWebApp");

app.UseStaticFiles(); // Para wwwroot
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = "/Resources"
});


app.UseAuthorization();

app.MapControllers();

app.Run();
