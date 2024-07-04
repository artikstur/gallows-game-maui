using Microsoft.Maui.Layouts;

namespace GallowsGame.Pages;

public partial class GamePage : ContentPage
{
	private string userText;
	public GamePage(string userText)
	{
		InitializeComponent();
		this.userText = userText;

        var TopBar = new StackLayout()
        {
            Children = { },
            BackgroundColor = Colors.Pink,
            HeightRequest = 150,
			HorizontalOptions = LayoutOptions.FillAndExpand,
        };

		var LeftCenterBox = new StackLayout()
		{
            BackgroundColor = Colors.Beige,
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
}