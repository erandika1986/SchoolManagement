using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolManagement.Business;
using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.Master;
using SchoolManagement.Util;
using SchoolManagement.WebApi.Helpers;
using SchoolManagement.WebApi.Infrastructure.AutofacModules;

namespace SchoolManagement.WebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //public Startup(IWebHostEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    this.Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDbContext(Configuration);
            services.EnableJWTAuthentication(Configuration);
            services.AddSwagger();
            services.EnableCors(Configuration);
            services.AddControllers();

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule(Configuration["SMMasterDbConnectionString"]));

            return new AutofacServiceProvider(container.Build());
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterType<AuthSQLServerTenantProvider>().As<ITenantProvider>().InstancePerDependency();
        //    builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
        //    builder.RegisterType<SMUow>().As<ISMUow>().InstancePerDependency();
        //    builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
        //    builder.RegisterType<AuthService>().As<IAuthService>().InstancePerDependency(); 
        //    builder.RegisterType<AcademicLevelService>().As<IAcademicLevelService>().InstancePerDependency();
        //    builder.RegisterType<ClassNameService>().As<IClassNameService>().InstancePerDependency();
        //    builder.RegisterType<SubjectService>().As<ISubjectService>().InstancePerDependency();
        //    builder.RegisterType<StudentService>().As<IStudentService>().InstancePerDependency();
        //    builder.RegisterType<AssessmentTypeService>().As<IAssessmentTypeService>().InstancePerDependency();
        //    builder.RegisterType<AcademicYearService>().As<IAcademicYearService>().InstancePerDependency();
        //    builder.RegisterType<SubjectClassTeacherService>().As<ISubjectClassTeacherService>().InstancePerDependency();
        //    builder.RegisterType<SubjectTeacherService>().As<ISubjectTeacherService>().InstancePerDependency(); 
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Start Manually Added Codes

            IdentityHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //Ended Manually Added Codes
        }
    }

    public static class CustomExtensionMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MasterDBContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration["SMMasterDbConnectionString"],
                                        sqlServerOptionsAction: sqlOptions =>
                                        {
                                            //sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                        });
            });


            services.AddDbContext<SMDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration["SMDbConnectionString"],
                                        sqlServerOptionsAction: sqlOptions =>
                                        {
                                            //sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                        });
            });

            return services;
        }

        public static IServiceCollection EnableJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var context = services.BuildServiceProvider()
                 .GetService<MasterDBContext>();

            var schools = context.Schools.Where(t => t.IsActive == true).ToList();

            services.AddAuthentication
                (cfg =>
                {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,

                   ValidIssuer = configuration["Tokens:Issuer"],
                   ValidAudiences = new List<string>
                   {
                         "mobileapp","webapp"
                   },

                   IssuerSigningKeyResolver = (string token, SecurityToken securityToken, string kid, TokenValidationParameters validationParameters) =>
                   {
                       List<SecurityKey> keys = new List<SecurityKey>();

                       var school = schools.FirstOrDefault(t=>t.APIKey.ToString().ToUpper()==kid.ToUpper());
                       if(school!=null)
                       {
                           keys.Add(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(school.SecretKey.ToString())));
                       }


                       return keys;
                   }


               };
           });



            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dynami School Management. - Web API",
                    Version = "v1",
                    Description = "The web service for Dynami School Management System",
                    TermsOfService = new Uri("https://example.com/terms")
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    //BearerFormat = "JWT",
                    //Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });

            return services;

        }

        public static IServiceCollection EnableCors(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            //})
            //.AddControllersAsServices();

            var allowedOrigins = new List<string>();
            var allowOrigins = configuration["AllowedOrigins"].Split(",");

            services.AddCors(options =>
            {
                options.AddPolicy(name:"CorsPolicy",
                    builder => builder.WithOrigins(allowOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }


    }
}
