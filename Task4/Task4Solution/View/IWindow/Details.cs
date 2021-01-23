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
        public Details()
        {
            DetailsWindow = new DetailsWindow();
        }
        public void Show()
        {
            DetailsWindow.Show();
            DetailsWindow = new DetailsWindow();
        }
    }
}
