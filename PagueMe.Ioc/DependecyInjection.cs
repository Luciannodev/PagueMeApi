using Microsoft.Extensions.DependencyInjection;
using PagueMe.Application.Interfaces;
using PagueMe.Application.UseCase;
using PagueMe.Domain.Repositories;
using PagueMe.Infra.DataProvider.Repositories;

namespace PagueMe.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services)
        {
            //mysql
            //services.AddMySqlDataSource(configuration.GetConnectionString("Default")!);
            //repository
            services.AddScoped<ICreditorRepository, CreditorRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            //usecase
            services.AddScoped<ICreditorUseCase, CreditorUseCase>();
            services.AddScoped<ILoanUseCase, LoanUseCase>();



            return services;
        }
    }
}
