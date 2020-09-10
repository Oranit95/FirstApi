using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubUsers.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using GithubUsers.Logics;

namespace GithubUsers
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
                           .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddHttpClient();
            services.AddScoped<IGitHubUsersRepository, GitHubUsersRepository>();
            services.AddScoped<IUserExtractData, UserExtractData>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => 
                endpoints.MapControllers()
            );

          //  app.UseMvc();
            app.Run(async (context) =>
            {
                if (string.IsNullOrWhiteSpace(context.Request.Path) || context.Request.Path == "/")
                {
                    await context.Response.WriteAsync("hELLO wORLD");
                }
                //else
                //{
                //    context.Response.StatusCode = 404;
                //}
            });

        }
    }
}
