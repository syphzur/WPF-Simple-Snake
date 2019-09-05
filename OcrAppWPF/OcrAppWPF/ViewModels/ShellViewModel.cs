using Caliburn.Micro;
using Newtonsoft.Json;
using OcrApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebSocketSharp;

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
