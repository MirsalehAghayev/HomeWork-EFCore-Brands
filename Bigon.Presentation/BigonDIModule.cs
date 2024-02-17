using Autofac;
using Bigon.DataAccessLayer;
using Bigon.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Presentation
{
    public class BigonDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembly = typeof(IRepositoryReference).Assembly;

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var type = typeof(IDataAccessLayerReference).Assembly.GetType("Bigon.DataAccessLayer.Contexts.DataContext");
            builder.RegisterType(type).As<DbContext>().InstancePerLifetimeScope();
        }
    }
}
