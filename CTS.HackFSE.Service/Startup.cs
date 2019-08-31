using System.Net;
using CTS.HackFSE.Business.Implementation;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.DataAccess;
using CTS.HackFSE.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;

namespace CTS.HackFSE.Service
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
            services.AddMvc();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "FSE API",
                    Description = "FSE ASP.NET Core 2.0 Web API",
                    TermsOfService = "None",
                });
             });

                    string connStr = Microsoft
                    .Extensions
                    .Configuration
                    .ConfigurationExtensions
                    .GetConnectionString(this.Configuration, "HackFSE");
            services.AddScoped<ITaskBO, TaskBO>();
            services.AddScoped<IProjectBO, ProjectBO>();
            services.AddScoped<IUserInfoBO, UserInfoBO>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserInfoRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddDbContext<HackFSEContext>(options => options.UseSqlServer(connStr));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors((cors) =>
            {
                cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });

            // Exception handling in a single place
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FSE API V1");
            });
        }
    }
}
