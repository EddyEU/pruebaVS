namespace Tns.Aerolinea.Application.DI
{
    using Autofac;
    using Data.Repositories;
    using Domain.DomainContracts;
    using Domain.RepositoriesContracts;
    using Domain.Services;

    public class DependencyInjectionContainer
    {
        public static IContainer Container { get; private set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static void InitializeContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            #region Repository

            builder.RegisterType<LoginRepository>().As<ILoginRepository>();
            builder.RegisterType<VueloRepository>().As<IVueloRepository>();
            builder.RegisterType<ReservaRepository>().As<IReservaRepository>();

            #endregion Repository

            #region Domain

            builder.RegisterType<LoginDomain>().As<ILoginDomain>();
            builder.RegisterType<VueloDomain>().As<IVueloDomain>();
            builder.RegisterType<ReservaDomain>().As<IReservaDomain>();

            #endregion Domain

            Container = builder.Build();
        }
    }
}