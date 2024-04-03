using Microsoft.EntityFrameworkCore;
using PagueMe.Application.Interfaces;
using PagueMe.Application.UseCase;
using PagueMe.Domain.Repositories;
using PagueMe.Infra.DataProvider.Context;
using PagueMe.Infra.DataProvider.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
String? ConnectionString = builder.Configuration.GetConnectionString("MysqlConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));
//repository
builder.Services.AddScoped<ICreditorRepository, CreditorRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
//usecase
builder.Services.AddScoped<ICreditorUseCase, CreditorUseCase>();
builder.Services.AddScoped<ILoanUseCase, LoanUseCase>();

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
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
