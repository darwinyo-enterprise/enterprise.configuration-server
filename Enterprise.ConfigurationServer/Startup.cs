using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.Models.NetStandard;
using Enterprise.Helpers.NetStandard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Enterprise.Constants.NetStandard;
using Enterprise.ConfigurationServer.Extension;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Microsoft.EntityFrameworkCore;
using Enterprise.ConfigurationServer.MockData;

namespace Enterprise.ConfigurationServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Required in all applications
            InitializeStartupHelper.InitializeStaticFields(Configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConfigurationDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(ConfigurationNames.ConfigurationConnection),
                    b => b.MigrationsAssembly("Enterprise.ConfigurationServer"));
            });

            // NOTE : Must Placed Before AddMvc
            services.AddCors();

            services.AddMvc();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(Policies.read_only_access_policy, builder =>
                {
                    builder.RequireScope(ConfigurationServerScopes.read_only_access, ConfigurationServerScopes.full_access);
                });
                opt.AddPolicy(Policies.write_access_policy, builder =>
                {
                    builder.RequireScope(ConfigurationServerScopes.write_access, ConfigurationServerScopes.full_access);
                });
            });

            // Register Dependencies Injections
            services.RegisterDependencies();

            services.AddAuthentication(Config.BearerSchema)
                .AddIdentityServerAuthentication(options =>
                {
                    // Depends on Configuration DB Context
                    options.Authority = Urls.AuthorizationServer_URL;
                    options.RequireHttpsMetadata = true;
                    options.ApiName = ApiNames.configurationserver;
                    options.ApiSecret = APISecrets.configurationserver;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }


            // NOTE : No backslash endings, Must Placed Before AddMvc
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();

        }
    }
}
