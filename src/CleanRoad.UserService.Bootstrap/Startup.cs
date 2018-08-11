using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.FluentBuilder;
using AutoMapper.Extensions.Autofac.DependencyInjection;
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

namespace CleanRoad.UserService.Bootstrap
{
    public class Startup
    {
        private IConfiguration configuration;
        private const string ApplicationPrefix = "CleanRoad.UserService";

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<UserServiceContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
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
                .RegisterTypeAsTransient<UserServiceContext>()
                .RegisterTypeAsTransient<TbUsersRepository, ITbUsersRepository>();
        }
    }
}
