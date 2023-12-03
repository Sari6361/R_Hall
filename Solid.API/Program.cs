using Solid.Core.Repositories;
using Solid.Core.Service;
using Solid.Data;
using Solid.Data.Repositories;
using Solid.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<ICustomerRepository,CustomerRepository>();
builder.Services.AddSingleton<ICateringRepository,CateringRepository>();
builder.Services.AddSingleton<IEventRepoistory,EventRepository>();

builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICateringService, CateringService>();
builder.Services.AddSingleton<IEventService, EventService>();




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
