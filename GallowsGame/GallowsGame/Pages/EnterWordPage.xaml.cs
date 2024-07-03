using GallowsGame.Utils;
using Microsoft.Maui.Layouts;

namespace GallowsGame.Pages;

public partial class EnterWordPage : ContentPage
{
    public EnterWordPage()
    {
        InitializeComponent();

        var keyboard = KeyboardBuilder.CreateKeyboard();

        var keyboardLayout = new FlexLayout()
        {

            WidthRequest = 700,
            JustifyContent = FlexJustify.Center,
            //VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        var keyboardBox = new StackLayout()
        {

            Children = { keyboardLayout },
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
        };

        foreach (var item in keyboard)
        {
            keyboardLayout.Children.Add(item);
        }

        keyboardLayout.Wrap = FlexWrap.Wrap;

        Label titleLabel = new Label()
        {
            Text = "Раунд 1",
            TextColor = Colors.Red,
            FontSize = 45,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        var pauseImage = new Image()
        {
            HeightRequest = 100,
            WidthRequest = 100,
            Source = "pausebttn.png",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        var emptyLabel = new Label()
        {
            Text = "Раунд",
            FontSize = 45,
            Opacity = 0,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };
        var topStack = new FlexLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            Children = { emptyLabel, titleLabel, pauseImage },
            JustifyContent = FlexJustify.SpaceBetween,
        };

        Label enterWordLabel = new Label()
        {
            Text = "Введите слово",
            FontSize = 35,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        Label clueLabel = new Label()
        {
            Text = "(3-8 букв)",
            FontSize = 23,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        var enterWordStack = new StackLayout()
        {
            Padding = 30,
            Children = { enterWordLabel, clueLabel },
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        var enterWordImage = new Image()
        {
            WidthRequest = 450,
            HeightRequest = 150,
            Source = "inroductory_line.png",
        };

      

        StackLayout grid = new StackLayout
        {
            Children = { topStack, enterWordStack, enterWordImage, keyboardBox },
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        FlexLayout.SetBasis(grid, new FlexBasis(1f, true));

       
        var backgroundImage = new Image
        {
            Source = "background.png",
            Aspect = Aspect.AspectFill,
        };

        Content = new Grid
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                backgroundImage,
                grid 
            }
        };
    }
}
