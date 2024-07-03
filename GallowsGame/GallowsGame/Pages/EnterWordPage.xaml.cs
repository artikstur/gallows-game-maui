using GallowsGame.Utils;
using Microsoft.Maui.Layouts;

namespace GallowsGame.Pages;

public partial class EnterWordPage : ContentPage
{
    Label userTextLabel = new Label()
    {
        Text = "",
        FontSize = 36,
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
}
