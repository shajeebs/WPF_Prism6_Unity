using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Windows;
using Prism.Modularity;
using Prism.Modularity.Module;
using System;

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
            return ModuleCatalog.CreateFromXaml(new Uri("catalog.xaml", UriKind.Relative)));
        }
    }
}