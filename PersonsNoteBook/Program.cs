using PersonsNoteBook.Services.Interfaces;
using PersonsNoteBook.Core.Interfaces;
using PersonsNoteBook.Infrastructure.Repositories;
using PersonsNoteBook.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PersonsNoteBook.Infrastructure.Mapper;
using PersonsNoteBook.Services.Mapper;
using PersonsNoteBook.Services.EventsHandler;
using PersonsNoteBook.Extensions;
using FluentValidation;
using PersonsNoteBook.Services.Commands;
using PersonsNoteBook.Services.Behaviors;
using PersonsNoteBook.Services.Validations;
using PersonsNoteBook.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<DBContextClass>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ILoggingRepository, LoggingRepository>();

builder.Services.AddAutoMapper(typeof(PersonModelProfile), typeof(PersonDtoProfile));
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(PersonCreatedDomainEventHandler).Assembly);

    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddScoped<IValidator<DeleteAddressCommand>, DeleteAddressCommandValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
