using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.IWindow
{
    public class Add : ViewModel.IWindow
    {
        private AddWindow AddWindow;
        public Add()
        {
            AddWindow = new AddWindow();
        }
        public void Show()
        {
            AddWindow.Show();
            AddWindow = new AddWindow();
        }
    }
}
