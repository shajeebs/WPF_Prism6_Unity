using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace EmailClient.UI
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog()
            {
                ModulePath = @".\Modules"
            };
        }
    }
}