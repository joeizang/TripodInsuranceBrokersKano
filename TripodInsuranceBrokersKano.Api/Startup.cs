using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Context;
using TripodInsuranceBrokersKano.Infrastructure.DataService;
using TripodInsuranceBrokersKano.Infrastructure.Repository;
using TripodInsuranceBrokersKano.Infrastructure.Services;
using TripodInsuranceBrokersKano.Infrastructure.Specifications.ClientSpecs;

namespace TripodInsuranceBrokersKano.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(
                    IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44393/";
                    options.ApiName = "tripodinsurancebrokersapi";
                });

            services.AddDbContext<TripodContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper();
            services.AddScoped<IRepository<Client>, GenericRepository<Client>>();
            services.AddScoped<ClientDataService>();
            services.AddTransient<ISpecification<Client>, ClientSpec>();
            services.AddTransient<UserResolverService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
