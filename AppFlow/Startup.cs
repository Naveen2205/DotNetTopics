using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AppFlow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using AppFlow.CommonInterface;
using AppFlow.Connections;
using AppFlow.Controllers;
using AppFlow.Mappers;
using AppFlow.Models;
using AppFlow.Query;
using AppFlow.Query.Home;
using SimpleInjector;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using SimpleInjector.Integration.Web.Mvc;
using AppFlow.Redis;
using AppFlow.CommonClass.Grid;

namespace AppFlow
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
            services.AddControllers();
            services.AddStackExchangeRedisCache(
                    options => options.Configuration = Configuration["RedisConnectionString"]
                ); 
            services.AddSingleton<IHomeService, HomeService>();
            //Get DI
            services.AddSingleton(typeof(IMappingHandler<HomeViewMapping, GridDataResult<IEnumerable<GridResultRow<GridResultCell>>>>), typeof(HomeViewMapperBase));
            services.AddSingleton(typeof(IQueryHandler<HomeFetchQuery, IEnumerable<HomeModel>>), typeof(HomeFetchQueryHandler));
            services.AddSingleton(typeof(IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>>), typeof(HomeRowMapperBase));
            services.AddSingleton(typeof(IQueryHandler<HomeCreateQuery, IEnumerable<HomeModel>>), typeof(HomeInsertQueryHandler));
            //Post DI
            services.AddSingleton(typeof(IMappingHandler<HomeRowMapping, GridResultRow<GridResultCell>>), typeof(HomeRowMapperBase));
            //Update DI
            services.AddSingleton(typeof(IQueryHandler<HomeUpdateQuery, IEnumerable<HomeModel>>), typeof(HomeUpdateQueryHandler));
            //Delete DI
            services.AddSingleton(typeof(IQueryHandler<HomeDeleteQuery, IEnumerable<HomeModel>>), typeof(HomeDeleteQueryHandler));
            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddSingleton<IConnectors, Connectors>();
            //container = new Container();
            /*var repository = container.GetInstance<IHomeService>();
            container.Register<IHomeService, HomeService>(Lifestyle.Transient);
            container.Register(typeof(IQueryHandler<>), typeof(AbstractQueryHandler<>), Lifestyle.Singleton);
            
            
            //container.Register( typeof(ITransientAutoBind<>), typeof(IAutoBind<>), Lifestyle.Singleton);
            container.Verify();
            DependencyResolver.SetResolver(
                    new SimpleInjectorDependencyResolver(container)
                );*/
             
            //services.AddSingleton<IHomeService, HomeService>();
            //services.AddSingleton(typeof(IQueryHandler<>), typeof(AbstractQueryHandler<>));
            //container.Register(typeof(IQueryHandler<>), typeof(AbstractQueryHandler<>), Lifestyle.Singleton);
            //container.Register(typeof(IQueryHandler<>), typeof(AbstractQueryHandler<>));
            //container.Register(typeof(AbstractQueryHandler<>));
            /*var repositoryAssembly = typeof(HomeService).Assembly;
            var registrations = 
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace.StartsWith("AppFlow.Services")
                from service in type.GetInterfaces()
                select new {service, implementation = type};
                Console.WriteLine("Registration = "+ registrations);

                foreach (var reg in registrations)
                {
                    Console.WriteLine("reg service = "+ reg.service);
                    Console.WriteLine("reg implementation = "+ reg.implementation);
                    services.AddSingleton(reg.service, reg.implementation);
                }*/
               
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppFlow", Version = "v1" });
            });
        }

        /*public static void RegisterAutoBindings(this Container container, IEnumerable<Assembly> assemblies)
        {
            var registrations = from type in assemblies.SelectMany(
                    x => x.GetExportedTypes()
                ).Where(x => x.IsClass)
                from service in type.GetInterfaces()
                    .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IAutoBind<>))
                select new {Service = service.GetGenericArguments().First(), Implementation = type};

            foreach (var reg in registrations)
            {
                var isTransient = reg.Implementation.GetInterfaces().Any(
                        x => x.IsGenericType &&
                        x.GetGenericTypeDefinition() == typeof(ITransientAutoBind<>));
                    container.Register(reg.Service, reg.Implementation, isTransient ? Lifestyle.Transient : LifeStyle.Singleton);
                )
            }
        }*/

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppFlow v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "Default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
