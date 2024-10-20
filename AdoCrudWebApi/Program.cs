using AdoCrudWebApi.Data.Contract;
using AdoCrudWebApi.Data.Implementation;
using AdoCrudWebApi.Services.Contract;
using AdoCrudWebApi.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
