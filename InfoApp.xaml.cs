namespace MyAquariumCheck;

public partial class InfoApp : ContentPage
{
	public InfoApp()
	{
		InitializeComponent();
	}

    private void OnButtonHomeClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
    }

    private void OnButtonInfoClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(new MainPage(), true);
    }
}