using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.FluentBuilder;
using AutoMapper.Extensions.Autofac.DependencyInjection;
using CleanRoad.UserService.Cqrs.Abstractions.Bus;
using CleanRoad.UserService.Cqrs.Bus;
using CleanRoad.UserService.Logic.Abstractions.Cryptography;
using CleanRoad.UserService.Logic.Cryptography;
using CleanRoad.UserService.Repositories;
using CleanRoad.UserService.Repositories.Abstractions;
using CleanRoad.UserService.Repositories.Context;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CleanRoad.UserService.Bootstrap
{
    public class Startup
    {
        private IConfiguration configuration;
        private readonly IHostingEnvironment environment;
        private const string ApplicationPrefix = "CleanRoad.UserService";
        private const string CorsPolicyName = "AllowSpecific";

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options => options.AddPolicy(Startup.CorsPolicyName, builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();

                if (!this.environment.IsDevelopment())
                {
                    return;
                }
                
                builder.AllowAnyOrigin();
            }));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(Startup.CorsPolicyName);
            
            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var applicationAssemblies = DependencyContext
                .Default
                .CompileLibraries
                .SelectMany(lib => lib.Assemblies)
                .Where(assemblyName => assemblyName.StartsWith(Startup.ApplicationPrefix))
                .Select(assemblyName => Assembly.Load(assemblyName.Replace(".dll", "")))
                .ToArray();

            new AutofacFluentBuilder(builder.AddMediatR(applicationAssemblies).AddAutoMapper(applicationAssemblies))
                .RegisterTypeAsScoped<CommandBus, ICommandBus>()
                .RegisterTypeAsTransient<UserServiceContext>()
                .RegisterTypeAsTransient<TbUsersRepository, ITbUsersRepository>()
                .RegisterTypeAsSingleton<Hasher, IHasher>();
        }
    }
}
