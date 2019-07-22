using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.WebApi.DataAccess.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Example.WebApi
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
            AppConfig.DbConnection = Configuration.GetConnectionString("DbConnection");
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(o => o.AllowEmptyInputInBodyModelBinding = true)
                   .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                   .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver());
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
                app.UseHsts();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetSection("AllowedHosts").Value);
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
