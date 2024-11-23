using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<LoginAttemptManager>().As<ILoginAttemptService>();
			builder.RegisterType<EfLoginAttemptDal>().As<ILoginAttemptDal>();

			builder.RegisterType<SystemLogManager>().As<ISystemLogService>();
			builder.RegisterType<EfSystemLogDal>().As<ISystemLogDal>();

			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();

		}
	}
}