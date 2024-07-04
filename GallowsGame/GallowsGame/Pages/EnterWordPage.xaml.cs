using GallowsGame.Utils;
using Microsoft.Maui.Layouts;
using System.Security.AccessControl;
using System.Xml.XPath;

namespace GallowsGame.Pages;

public partial class EnterWordPage : ContentPage
{
    Label userTextLabel = new Label()
    {
        Text = "",
        FontSize = 34,
        TextColor = Colors.Navy,
        FontFamily = "Maki-Sans",
        VerticalOptions = LayoutOptions.Center,
        HorizontalOptions = LayoutOptions.Center
    };
    public string userText { get; set; }


    public EnterWordPage()
    {
        InitializeComponent();

        var keyboard = KeyboardBuilder.CreateKeyboard(this);

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
            FontSize = 48,
            FontFamily = "Maki-Sans",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        var pauseImageBttn = new ImageButton()
        {
            HeightRequest = 80,
            WidthRequest = 80,
            Source = "pausebttn.png",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center,
             Margin = new Thickness(0, 4, 10, 0),
        };

        pauseImageBttn.Clicked += OnPauseButtonClicked;

        var emptyLabel = new Label()
        {
            Text = "Раунд",
            FontSize = 45,
            FontFamily = "Maki-Sans",
            Opacity = 0,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };
        var topStack = new FlexLayout()
        {
            HorizontalOptions = LayoutOptions.Fill,
            Children = { emptyLabel, titleLabel, pauseImageBttn },
            JustifyContent = FlexJustify.SpaceBetween,
        };

        Label enterWordLabel = new Label()
        { 
            Text = "Введите слово",
            TextColor = Colors.Navy,
            FontSize = 45,
            FontFamily = "Maki-Sans",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0,40,0,0)
        };

        Label clueLabel = new Label()
        {
            Text = "(3-8 букв)",
            FontFamily = "Maki-Sans",
            FontSize = 23,
            TextColor = Colors.Navy,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center
        };

        var enterWordStack = new StackLayout()
        {
            Padding = 20,
            Children = { enterWordLabel, clueLabel },
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };


        var enterWordImage = new Image()
        {
            WidthRequest = 500,
            HeightRequest = 200,
            Source = "inroductory_line.png",
        };

        var checkWordImage = new Image()
        {
            WidthRequest = 70,
            HeightRequest = 70,
            Source = "confirm_bttn.png",
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 0, 400, 0)
        };

        Button innerBtn = new Button()
        {
            WidthRequest = 70,
            HeightRequest = 70,
            BackgroundColor = Colors.Transparent,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 0, 400, 0)
        };

        innerBtn.Clicked += OnSubmitButtonClicked;

        var checkWordBox = new Grid()
        {
            Children =
            {
                checkWordImage,
                innerBtn
            }
        };

        var enterWordBox = new Grid()
        {
            Children = { enterWordImage, userTextLabel, checkWordBox }
        };

        StackLayout grid = new StackLayout
        {
            Children = { topStack, enterWordStack, enterWordBox, keyboardBox },
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
    public void OnKeyboardButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Colors.Aqua;
        if (userTextLabel.Text.Length < 8)
        {
            userTextLabel.Text += button.Text;
            userText = userTextLabel.Text;
        }
    }

    public void OnClearButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Colors.Aqua;
        if (userTextLabel.Text.Length > 0)
        {
            userTextLabel.Text = userTextLabel.Text.Remove(userTextLabel.Text.Length - 1);
            userText = userTextLabel.Text;
        }
    }

    public void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Colors.Aqua;

        if (!(userTextLabel.Text.Length > 2 && userTextLabel.Text.Length < 9))
        {
            return;
        }
    }

    public void OnPauseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MenuPage());
    }
}
