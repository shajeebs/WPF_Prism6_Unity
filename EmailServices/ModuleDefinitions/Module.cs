using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using EmailInterfaces;
using EmailServices.Services;

namespace EmailServices.ModuleDefinitions
{
    public class Module : IModule
    {
        private IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            this._container = container;
        }
        public void Initialize()
        {
            this._container.RegisterInstance<IEmailService>(new EmailService());
        }
    }
}
