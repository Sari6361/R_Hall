using Solid.API.Mapping;
using Solid.Core;
using Solid.Core.Repositories;
using Solid.Core.Service;
using Solid.Data;
using Solid.Data.Repositories;
using Solid.Service.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(options=>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICateringRepository,CateringRepository>();
builder.Services.AddScoped<IEventRepoistory,EventRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICateringService, CateringService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddAutoMapper(typeof(Mapping), typeof(ApiMappingProfile));

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
