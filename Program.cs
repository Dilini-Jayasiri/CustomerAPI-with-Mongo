using Microsoft.Extensions.Options;
using MongoDB.Driver;
using mongoDemo.Models;
using mongoDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CustomerStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(CustomerStoreDatabaseSettings)));

builder.Services.AddSingleton<ICustomerStoreDatabaseSetting>(sp =>
sp.GetRequiredService<IOptions<CustomerStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<String>("CustomerStoreDatabaseSettings:ConnectionString")));


builder.Services.AddScoped<ICustomerServices, CustomerService>();


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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
