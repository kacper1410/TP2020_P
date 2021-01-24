namespace View.IWindow
{
	public class Add : ViewModel.IWindow
    {
        private AddWindow AddWindow;
        private static bool _open;
        public Add()
        {
            AddWindow = new AddWindow();
            _open = false;
        }

        public void Close()
        {
            AddWindow.Close();
            AddWindow = new AddWindow();
            _open = false;
        }

        public void SetViewModel(ViewModel.ViewModel viewModel)
        {
            AddWindow.DataContext = viewModel;
        }

        public void Show()
        {
            if (!_open)
            {
                AddWindow.Show();
                _open = true;
            }
        }
    }
}
