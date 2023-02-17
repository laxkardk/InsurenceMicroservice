
using Insurance.PurchaseAPI.CQRS.Queries.Handlers;
using Insurance.PurchaseAPI.CQRS.Queries.Interfaces;
using Insurance.PurchaseAPI.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
           {
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
           });

builder.Services.AddScoped<IInsurancePurchaseCommand, InsurancePurchaseCommandHandler>();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPICQRS v1"));

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseRouting();

app.MapControllers();



app.MapControllers();


app.Run();
