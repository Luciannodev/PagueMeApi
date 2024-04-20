using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PagueMe.Application.Interfaces;
using PagueMe.Application.UseCase;
using PagueMe.DataProvider.Config;
using PagueMe.DataProvider.Context;
using PagueMe.DataProvider.Repositories;
using PagueMe.Domain.Interface.Repositories;
using PagueMe.Domain.Interface.Security;
using PagueMe.Infra.ExternalServices.Security;

namespace PagueMe.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfigurationRoot configuration)
        {

            //mysql

            Console.WriteLine(configuration.GetDebugView());
            services.AddDbContext<ApplicationDbContext>();
            //repository
            services.AddScoped<ICreditorRepository, CreditorRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IAccount, Account>();
            //usecase
            services.AddScoped<ICreditorUseCase, CreditorUseCase>();
            services.AddScoped<ILoanUseCase, LoanUseCase>();
            services.AddScoped<IAccountUseCase, AccountUseCase>();

            //services.Configure<DataBaseSettings>(configuration.GetSection("DataBaseSettings"));
            services.AddOptions<DataBaseSettings>()
                .BindConfiguration("Database")
                .Bind(configuration);



            return services;
        }
    }
}
