using EmailInterfaces;
using EmailServices.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace EmailServices
{
    public class EsModule : IModule
    {
        private IUnityContainer _container;

        public EsModule(IUnityContainer container)
        {
            this._container = container;
        }
        public void Initialize()
        {
            //this._container.RegisterInstance<IEmailService>(new EmailService());
            this._container.RegisterType<IEmailService, EmailService>();
        }
    }
}
