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
                .InstancePerDependency();

            builder.RegisterType<SMUow>()
                .As<ISMUow>()
                .InstancePerDependency();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerDependency();

            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .InstancePerDependency();

            builder.RegisterType<AcademicLevelService>()
                .As<IAcademicLevelService>()
                .InstancePerDependency();

            builder.RegisterType<ClassNameService>()
                .As<IClassNameService>()
                .InstancePerDependency();

            builder.RegisterType<SubjectService>()
                .As<ISubjectService>()
                .InstancePerDependency();

            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .InstancePerDependency();

            builder.RegisterType<AssessmentTypeService>()
                .As<IAssessmentTypeService>()
                .InstancePerDependency();

            builder.RegisterType<AcademicYearService>()
               .As<IAcademicYearService>()
               .InstancePerDependency();

            builder.RegisterType<SubjectClassTeacherService>()
                .As<ISubjectClassTeacherService>()
                .InstancePerDependency();

            builder.RegisterType<SubjectTeacherService>()
                .As<ISubjectTeacherService>()
                .InstancePerDependency(); 

            builder.RegisterType<TimeTableService>()
                .As<ITimeTableService>()
                .InstancePerDependency(); 


        }
    }
}
