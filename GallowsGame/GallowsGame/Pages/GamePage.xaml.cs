using Microsoft.Maui.Layouts;

namespace GallowsGame.Pages;

public partial class GamePage : ContentPage
{
    private string userText;  

    private int coinCount = 3; //3 по дефолту

    private string guessWord;

    public GamePage(string userText)
	{
		InitializeComponent();
		this.userText = userText;

        var gallowImage = new Image()
        {
            WidthRequest = 450,
            HeightRequest = 800,
            Source = "gallow_concept.png",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, -100, 0,0)
        };

        Label titleLabel = new Label()
        {
            Text = "Слово:",
            TextColor = Colors.Navy,
            FontSize = 40,
            FontFamily = "Maki-Sans",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        Label guessLabel = new Label()
        {
            Text = guessWord,
            TextColor = Colors.Red,
            FontSize = 55,
            FontFamily = "Maki-Sans",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };

        var pauseImageBttn = new ImageButton()
        {
            HeightRequest = 80,
            WidthRequest = 80,
            Source = "pausebttn.png",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, -60, 15, 0),
            BackgroundColor = Colors.Transparent,
        };

        Label coinCountText = new Label()
        {
            Text = coinCount.ToString(),
            TextColor = Colors.Black,
            FontSize = 40,
            FontFamily = "Maki-Sans",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Start
        };

        var coinImage = new Image()
        {
            HeightRequest = 50,
            WidthRequest = 50,
            Source = "coin.png",
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 0, -0, 0),
        };

        pauseImageBttn.Clicked += OnPauseButtonClicked;

        var TopBar = new StackLayout()
        {
            Children = {titleLabel,pauseImageBttn, coinImage, coinCountText, guessLabel},
            BackgroundColor = Colors.Pink,
            HeightRequest = 150,
			HorizontalOptions = LayoutOptions.FillAndExpand,
        };

		var LeftCenterBox = new StackLayout()
		{
            BackgroundColor = Colors.Beige,
            Children = { gallowImage},
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        var RightCenterBox = new StackLayout()
        {
            BackgroundColor = Colors.DarkBlue,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        var CenterBox = new FlexLayout()
        {
            Margin = new Thickness(30, 0),
            Children = {LeftCenterBox, RightCenterBox },
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        FlexLayout.SetBasis(LeftCenterBox, new FlexBasis(0.5f, true));
        FlexLayout.SetBasis(RightCenterBox, new FlexBasis(0.5f, true));

        Content = new StackLayout()
		{
			BackgroundColor = Colors.Aqua,
			Children = { TopBar, CenterBox }
		};
	}
    public void OnPauseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MenuPage());
    }
}