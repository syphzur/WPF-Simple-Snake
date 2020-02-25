using Caliburn.Micro;
using SnakeWPF.ViewModels;
using System.Windows;

namespace SnakeWPF
{
    public class Bootstraper : BootstrapperBase
    {
        public Bootstraper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<SnakeViewModel>();
        }
    }
}
