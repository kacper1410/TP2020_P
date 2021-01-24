namespace ViewModel
{
	public interface IWindow
    {
        void SetViewModel(ViewModel viewModel);
        void Show();

        void Close();
    }
}
