using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookRoom.Application.Infrastructure;
using BookRoom.Application.Infrastructure.AutoMapper;
using BookRoom.Application.Interfaces;
using BookRoom.Common;
using BookRoom.Infrastructure;
using BookRoom.Persistence;
using BookRoom.WebUI.Filters;
using NSwag.AspNetCore;
using System.Reflection;
using BookRoom.Application.Rooms.Commands.CreateRoom;
using BookRoom.Application.Rooms.Commands.DeleteRoom;

namespace BookRoom.WebUI
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddMediatR();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext using SQL Server Provider
            services.AddDbContext<BookRoomDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BookRoomDatabase"), x => x.MigrationsAssembly("BookRoom.Persistence")));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateRoomCommand>());

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerDocument(c =>
            {
                c.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "BookRoom API";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Mateusz Wyczawski",
                        Email = "wyczawski93@gmail.com",
                        Url = "https://pl.linkedin.com/in/mwyczawski"
                    };
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{id?}");
            });
        }
    }
}
