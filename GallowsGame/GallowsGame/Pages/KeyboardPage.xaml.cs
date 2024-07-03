namespace GallowsGame.Pages;

public partial class KeyboardPage : ContentPage
{
	public KeyboardPage()
	{
		InitializeComponent();
		Label label = new Label()
		{
			Text = "����"
		};

        Content = new StackLayout
        {
            Children = { label },
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };
    }
}