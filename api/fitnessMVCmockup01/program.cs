global using fitnessMVCmockup01.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FitnessContext>(options =>
{
    //found correct syntax of stackoverflow to reference Pomelo MySql//
    //var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));

    options.UseMySql(builder.Configuration.GetConnectionString("FitnessDb"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:8080/");
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//https://www.youtube.com/watch?v=pzFY45La2LE&t=754s
