using Microsoft.Extensions.DependencyInjection;
using Rackbook.Domain.Repositories;
using Rackbook.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rackbook.Infrastructure
{
    public static class DependencyInfrastructureService
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IItemGroupRepository, ItemGroupRepository>();
            services.AddScoped<IItemUnitRepository, ItemUnitRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IJournalEntryTypeRepository, JournalEntryTypeRepository>();
            services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();
            services.AddScoped<IJournalEntryDetailRepository, JournalEntryDetailRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IAccountDetailRepository, AccountDetailRepository>();
            services.AddScoped<INavigationItemRepository, NavigationItemRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICustomersAddressRepository, CustomersAddressRepository>();

        }
    }
}
