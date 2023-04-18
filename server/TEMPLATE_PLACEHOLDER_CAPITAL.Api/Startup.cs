using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core;
using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Filters;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Configuration;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(BadRequestFilter));
            }).AddJsonOptions(options => {
                DefaultSerializerOptions.SetOptions(options.JsonSerializerOptions);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TEMPLATE_PLACEHOLDER_CAPITAL API", Version = "v1" });
            });

            services.AddHttpContextAccessor();

            services
                .AddInfrastructureServices(Configuration.GetConnectionString("Core"))
                .AddCoreServices()
                .AddApiServices()
            ;

            services.AddCors();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                    if (Environment.IsProduction())
                    {
                        options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
                    }
                });

            services.AddAutoMapper(typeof(Startup), typeof(ITEMPLATE_PLACEHOLDER_CAPITALContext));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<IDbInitializer>();
                initializer.Initialize();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TEMPLATE_PLACEHOLDER_CAPITAL API v1"));
                app.UseCors(opt =>
                {
                    opt.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials()
                       .WithExposedHeaders("Content-Disposition")
                       .WithOrigins("https://localhost:*", "http://localhost:8080");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
