using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PagueMe.Application.Interfaces;
using PagueMe.Application.UseCase;
using PagueMe.DataProvider.Context;
using PagueMe.DataProvider.Repositories;
using PagueMe.Domain.Interface.Repositories;
using PagueMe.Domain.Interface.Security;
using PagueMe.Infra.Config;
using PagueMe.Infra.ExternalServices.Security;

namespace PagueMe.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfigurationRoot configuration)
        {

            //database
            services.AddDbContext<ApplicationDbContext>();
            //repository
            services.AddScoped<ICreditorRepository, CreditorRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IAccount, Account>();
            //usecase
            services.AddScoped<ICreditorUseCase, CreditorUseCase>();
            services.AddScoped<ILoanUseCase, LoanUseCase>();
            services.AddScoped<IAccountUseCase, AccountUseCase>();

            //configuration environment
            services.AddOptions<ClientSettings>()
                .BindConfiguration("ClientSettings")
                .Bind(configuration);



            return services;
        }
    }
}
