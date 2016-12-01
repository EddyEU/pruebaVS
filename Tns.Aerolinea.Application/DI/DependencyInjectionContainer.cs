namespace Tns.Aerolinea.Application.DI
{
    using Autofac;
    using Data.Repositories;
    using Domain.RepositoriesContracts;

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

            #endregion Repository

            #region Domain

            //builder.RegisterType<SolicitudReversionDomain>().As<ISolicitudReversionDomain>();

            #endregion Domain

            Container = builder.Build();
        }
    }
}