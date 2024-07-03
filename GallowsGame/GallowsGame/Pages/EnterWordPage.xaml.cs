using GallowsGame.Utils;

namespace GallowsGame.Pages;

public partial class EnterWordPage : ContentPage
{
    public EnterWordPage()
    {
        InitializeComponent();

        HorizontalStackLayout keyboardLayout = new HorizontalStackLayout
        {
            HeightRequest = 500,
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };
        Label label = new Label()
        {
            Text = "Test Layout",
        };

        VerticalStackLayout grid = new VerticalStackLayout
        {
            BackgroundColor = Colors.PeachPuff,
            Children = { label, keyboardLayout },
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        var keyboard = KeyboardBuilder.CreateKeyboard();
        foreach (var item in keyboard)
        {
            keyboardLayout.Children.Add(item);
        }

        Content = new VerticalStackLayout
        {
            BackgroundColor = Colors.PowderBlue,
            Children = { grid },
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
    }
}
