using Microsoft.EntityFrameworkCore;
using PolicyMasterService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Sql Connection
builder.Services.AddDbContext<PolicyMasterDBContext>(dbConn => dbConn.UseSqlServer(builder.Configuration.GetConnectionString("PolicyMasterDBConn")));
builder.Services.AddMediatR(mediatr => mediatr.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
