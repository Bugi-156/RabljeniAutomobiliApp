namespace RabljeniAutomobiliApp;

public partial class SecondPage : ContentPage
{
    public SecondPage()
    {
        InitializeComponent();
    }

    private async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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