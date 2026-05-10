namespace RabljeniAutomobiliApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void GoToSecondPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SecondPage());
    }

    private async void OnImageTapped(object sender, TappedEventArgs e)
    {
        if (sender is Image image)
        {
            await image.ScaleTo(1.1, 100);

            await image.ScaleTo(1.0, 100);
        }
    }
}