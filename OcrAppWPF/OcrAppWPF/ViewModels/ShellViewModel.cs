using Caliburn.Micro;

namespace OcrAppWPF.ViewModels
{
    class ShellViewModel: Conductor<object>
    {
        public void LoadFilesPage()
        {
            ActivateItem(new FilesViewModel());
        }

        public void LoadDataPage()
        {
            ActivateItem(new DataViewModel());
        }

    }
}
