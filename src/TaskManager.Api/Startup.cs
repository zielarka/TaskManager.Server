using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TaskManager.Infrastructure.CQRS.Commands.ToDoTask;
using TaskManager.Infrastructure.CQRS.Queries.ToDoTask;
using TaskManager.Infrastructure.IoC;
using TaskManager.Persistence.Migrations;

namespace TaskManager.Api
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var serviceCollection = new ServiceCollection();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            #region DB
            services.AddDbContext<DataContext_Sqlite>(x => x.UseSqlite(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));
            #endregion

            #region MediatR
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(CreateTodoTaskCommand).Assembly);
            services.AddMediatR(typeof(GetAllToDoTaskQuery).Assembly);
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TaskManager",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
                }
                });
            });
            #endregion

            #region IoC
            var containerbuilder = new ContainerBuilder();
            containerbuilder.Populate(services);
            containerbuilder.RegisterModule(new ContainerModule());
            ApplicationContainer = containerbuilder.Build();
            #endregion

            #region CORS for http://localhost:3000
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            #endregion

            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors("AllowSpecificOrigin");
        }
    }
}
