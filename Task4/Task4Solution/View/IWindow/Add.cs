namespace View.IWindow
{
	public class Add : ViewModel.IWindow
    {
        private AddWindow AddWindow;
        public Add()
        {
            AddWindow = new AddWindow();
        }

        public void SetViewModel(ViewModel.ViewModel viewModel)
        {
            AddWindow.DataContext = viewModel;
        }

        public void Show()
        {
            AddWindow.Show();
            AddWindow = new AddWindow();
        }
    }
}
