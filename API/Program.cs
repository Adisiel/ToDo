using Application.Profiles;
using Application.Services;
using Application.Services.Interfaces;
using Application.Validators.CategoriaValidators;
using Core.Interfaces.Repositories;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ToDoContextDev").Replace("[DataDirectory]", Path.Combine(Directory.GetCurrentDirectory(), "App_Data"))));

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddAutoMapper(typeof(CategoriaProfile));
builder.Services.AddAutoMapper(typeof(TarefaProfile));

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AddCategoriaDTOValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UpdateCategoriaDTOValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
