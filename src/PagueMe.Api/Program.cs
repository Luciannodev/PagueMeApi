
using FluentValidation;
using FluentValidation.AspNetCore;
using PagueMe.Api.Dtos.Request;
using PagueMe.Api.Dtos.Vallidators;
using PagueMe.Api.Mapper;
using PagueMe.DataProvider.Context;
using PagueMe.Ioc;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(typeof(Program).Assembly))
    .AddJsonOptions(configure: options => { options.JsonSerializerOptions.IgnoreNullValues = true; });
builder.Services.AddTransient<IValidator<CreditorRequestDTO>, CreditorValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DtoMapper));
var app = builder.Build();


SeedData(app);

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




void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}
