using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using Enterprise.ConfigurationServer.Repository.ConfigurationDB;
using Enterprise.ConfigurationServer.UnitOfWork;
using Enterprise.Interfaces.NetStandard.Services;
using Enterprise.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.ConfigurationServer.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IIntegratedAppRepository, IntegratedAppRepository>();
            services.AddScoped<IApplicationConfigurationRepository, ApplicationConfigurationRepository>();
            services.AddScoped<IAppMenuRepository, AppMenuRepository>();
            services.AddScoped<IAppMenuCategoryRepository, AppMenuCategoryRepository>();
            services.AddScoped<IMenuPermittedRoleRepository, MenuPermittedRoleRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IConfigurationDBUnitOfWork, ConfigurationDBUnitOfWork>();

            // Depends on Static URL that Registered on DB
            services.AddScoped<ILoggingServices, LoggingServices>();
        }
    }
}
