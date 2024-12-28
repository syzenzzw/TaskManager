using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Interface;
using TaskManager.Repositorys;
    
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy( name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4002",
                "http://192.168.1.155:4000/").AllowAnyMethod().AllowAnyHeader();
        }
        );
}
);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("defaultconnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
