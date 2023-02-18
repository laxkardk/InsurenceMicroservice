using Insurance.CustomerAPI.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Insurance.CustomerAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CustomerDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDB")));
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssembly(typeof(Program).Assembly));

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
