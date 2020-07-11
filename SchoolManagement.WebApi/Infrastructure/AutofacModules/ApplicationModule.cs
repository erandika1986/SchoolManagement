using Autofac;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Business;
using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.Master;
using SchoolManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebApi.Infrastructure.AutofacModules
{
    public class ApplicationModule
        : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthSQLServerTenantProvider>()
    .As<ITenantProvider>()
    .InstancePerDependency();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<SMUow>()
                .As<ISMUow>()
                .SingleInstance();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AcademicLevelService>()
                .As<IAcademicLevelService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClassNameService>()
                .As<IClassNameService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SubjectService>()
                .As<ISubjectService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AssessmentTypeService>()
                .As<IAssessmentTypeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AcademicYearService>()
               .As<IAcademicYearService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<SubjectClassTeacherService>()
                .As<ISubjectClassTeacherService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SubjectTeacherService>()
                .As<ISubjectTeacherService>()
                .InstancePerLifetimeScope();


        }
    }
}
