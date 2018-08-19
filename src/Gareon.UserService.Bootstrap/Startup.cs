using System.IO.Compression;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.FluentBuilder;
using AutoMapper.Extensions.Autofac.DependencyInjection;
using Gareon.UserService.Bootstrap.Config;
using Gareon.UserService.Bootstrap.Services;
using Gareon.UserService.Constants;
using Gareon.UserService.Cqrs.Abstractions.Bus;
using Gareon.UserService.Cqrs.Bus;
using Gareon.UserService.Logic.Abstractions.Authentication;
using Gareon.UserService.Logic.Abstractions.Cryptography;
using Gareon.UserService.Logic.Authentication;
using Gareon.UserService.Logic.Cryptography;
using Gareon.UserService.Repositories;
using Gareon.UserService.Repositories.Abstractions;
using Gareon.UserService.Repositories.Context;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gareon.UserService.Bootstrap
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment environment;
        
        private static readonly string ApplicationPrefix = typeof(Startup).Assembly.GetName().Name.Replace("Bootstrap", "");
        private const string CorsPolicyName = "AllowSpecific";
        private const string AuthenticationSchema = "Bearer";
        private const string RedisCacheOptions = "RedisCacheOptions";

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var identityConfig = this.configuration
                .GetSection("IdentityConfig");

            var allowedOrigins = identityConfig
                .GetSection("Origins")
                .Get<string[]>();

            var clientId = identityConfig
                .GetSection("WebClient")
                .GetValue<string>("Name");

            var clientSecret = identityConfig
                .GetSection("WebClient")
                .GetValue<string>("Secret");

            var authority = identityConfig
                .GetValue<string>("Authority");
            
            services.AddMvc(options =>
                {
                    var requiredAuthorizedUser = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                    options.Filters.Add(new AuthorizeFilter(requiredAuthorizedUser));
                })
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

                if (this.environment.IsDevelopment())
                {
                    builder.AllowAnyOrigin();
                    return;
                }

                builder.WithOrigins(allowedOrigins);
            }));
            
            services.AddDistributedRedisCache(options =>
                this.configuration.GetSection(Startup.RedisCacheOptions).Bind(options));
            
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityResourceConfig.GetIdentityResource())
                .AddInMemoryApiResources(ApiResourceConfig.GetApiResource())
                .AddInMemoryClients(ClientConfig.GetClients(clientId, clientSecret, allowedOrigins));

            services.AddAuthentication(Startup.AuthenticationSchema)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = authority;
                    options.RequireHttpsMetadata = this.environment.IsProduction();
                    options.ApiName = ServiceNames.UserService;
                });

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            services.Configure<DatabaseConnectionOptions>(options =>
                this.configuration.GetSection(nameof(DatabaseConnectionOptions)).Bind(options));
            
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app)
        {
            
            app.UseCors(Startup.CorsPolicyName);
            
            app.UseIdentityServer();
            
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
                .RegisterTypeAsScoped<HttpContextAccessor, IHttpContextAccessor>()
                .RegisterTypeAsScoped<AuthenticationService, IResourceOwnerPasswordValidator>()
                .RegisterTypeAsScoped<AuthenticationService, IProfileService>()
                .RegisterTypeAsScoped<AuthenticationService, IAuthService>()
                .RegisterTypeAsScoped<DistributedCachedGrantStoreService, IPersistedGrantStore>()
                .RegisterTypeAsSingleton<CorsPolicyService, ICorsPolicyService>()
                .RegisterTypeAsTransient<UserServiceContext>()
                .RegisterTypeAsTransient<TbUsersRepository, ITbUsersRepository>()
                .RegisterTypeAsTransient<BlockedUsersRepository, IBlockedUsersRepository>()
                .RegisterTypeAsSingleton<Hasher, IHasher>()
                .RegisterInstance<Microsoft.Extensions.Hosting.IHostingEnvironment>(this.environment)
                .RegisterInstance<IConfiguration>(this.configuration);
        }
    }
}
