using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Bigon.Presentation
{
    public class BigonServiceProviderFactory : AutofacServiceProviderFactory
    {
        public BigonServiceProviderFactory()
            : base(Register) { }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<BigonDIModule>();
        }
    }
}
