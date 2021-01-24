using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.IWindow
{
    public class Details : ViewModel.IWindow
    {
        private DetailsWindow DetailsWindow;
        private static bool _open;
        public Details()
        {
            DetailsWindow = new DetailsWindow();
            _open = false;
        }

        public void Close()
        {
            DetailsWindow.Close();
            DetailsWindow = new DetailsWindow();
            _open = false;
        }

        public void SetViewModel(ViewModel.ViewModel viewModel)
        {
            DetailsWindow.DataContext = viewModel;
        }

        public void Show()
        {
            if (!_open)
            {
                DetailsWindow.Show();
                _open = true;
            }
        }
    }
}
