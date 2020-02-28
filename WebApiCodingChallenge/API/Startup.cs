using Autofac;
using Autofac.Extensions.DependencyInjection;
using WebApiCodingChallenge.Api.Extensions;
using WebApiCodingChallenge.Middlewares.Errors;
using WebApiCodingChallenge.Middlewares.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace WebApiCodingChallenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ModelValidationFilter));
            });

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "WebApiCodingChallenge.Web",
                    Version = "v1.0",
                    Description = "API for web api coding challenge",
                    Contact = new Contact
                    {
                        Name = "L B",
                        Email = "",
                        Url = $"https://github.com/b4ry"
                    }
                });

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "WebApiCodingChallenge.xml");
                setup.IncludeXmlComments(xmlPath);
            });

            ApplicationContainer = services.AddApplicationModules();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiCodingChallenge.Web V1.0");
            });

            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
