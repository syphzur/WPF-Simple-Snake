using Caliburn.Micro;
using OcrAppWPF.ViewModels;
using System.Windows;

namespace OcrAppWPF
{
    public class Bootstraper: BootstrapperBase
    {
        public Bootstraper()
        {
            Initialize();       
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
