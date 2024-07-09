using GallowsGame.Utils;
using GallowsGame.Utils.ApiClients.YandexApi;
using Microsoft.Maui.Layouts;

namespace GallowsGame.Pages;

public partial class EnterWordPage : ContentPage
{
    private Label userTextLabel = new Label()
    {
        Text = "",
        FontSize = 34,
        TextColor = Colors.Navy,
        FontFamily = "Maki-Sans",
        VerticalOptions = LayoutOptions.Center,
        HorizontalOptions = LayoutOptions.Center
    };
    private string userText  = "";

    public EnterWordPage()
    {
        InitializeComponent();
        CreateLayout();
    }

    public void CreateLayout()
    {
        var topBox = CreateTopLayout();
        var clueBox = CreateClueLayout();
        var enterWordBox = CreateEnterWordLayout();
        var keyboardBox = CreateKeyBoardLayout(700);

        StackLayout grid = new StackLayout
        {
            Children = { topBox, clueBox, enterWordBox, keyboardBox },
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

    private StackLayout CreateKeyBoardLayout(int boxSize)
    {
        var keyboard = KeyboardBuilder.CreateKeyboard(this, OnKeyboardButtonClicked, OnClearButtonClicked, true);

        var keyboardLayout = new FlexLayout()
        {
            WidthRequest = boxSize,
            JustifyContent = FlexJustify.Center,
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

        return keyboardBox;
    }

    public FlexLayout CreateTopLayout()
    {
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
            BackgroundColor = Colors.Transparent,
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

        return topStack;
    }

    public StackLayout CreateClueLayout()
    {
        Label enterWordLabel = new Label()
        {
            Text = "Введите слово",
            TextColor = Colors.Navy,
            FontSize = 45,
            FontFamily = "Maki-Sans",
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 40, 0, 0)
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

        return enterWordStack;
    }

    public Grid CreateEnterWordLayout()
    {
        var enterWordImage = new Image()
        {
            WidthRequest = 500,
            HeightRequest = 200,
            Source = "inroductory_line.png",
        };

        ImageButton innerBtn = new ImageButton()
        {
            Source = "confirm_bttn.png",
            WidthRequest = 70,
            HeightRequest = 70,
            BackgroundColor = Colors.Transparent,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 0, 400, 0)
        };

        innerBtn.Clicked += OnSubmitButtonClicked;

        var enterWordBox = new Grid()
        {
            Children = { enterWordImage, userTextLabel, innerBtn }
        };

        return enterWordBox;
    }

    public async void OnKeyboardButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        await button.ScaleTo(1.2, 100, Easing.Linear);
        await button.ScaleTo(1, 100, Easing.Linear);

        if (userTextLabel.Text.Length < 8)
        {
            userTextLabel.Text += button.Text;
            userText = userTextLabel.Text;
        }
    }

    public async void OnClearButtonClicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        await button.ScaleTo(1.2, 100, Easing.Linear);
        await button.ScaleTo(1, 100, Easing.Linear);

        if (userTextLabel.Text.Length > 0)
        {
            userTextLabel.Text = userTextLabel.Text.Remove(userTextLabel.Text.Length - 1);
            userText = userTextLabel.Text;
        }
    }

    public async void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        await button.ScaleTo(1.2, 100, Easing.Linear);
        await button.ScaleTo(1, 100, Easing.Linear);

        if (!(userTextLabel.Text.Length > 2 && userTextLabel.Text.Length < 9))
        {
            ShowError("минимум 3 буквы, максимум - 8");
            return; 
        }

        var apiClient = new ApiClient();
        var res = await apiClient.GetWordData(userTextLabel.Text);

        if (!res)
        {
            ShowError("введенное слово должно быть именем существительным в единственном числе");
            return;
        }

        await Navigation.PushAsync(new GamePage(userTextLabel.Text));
    }

    public async void OnPauseButtonClicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        await button.ScaleTo(1.2, 100, Easing.Linear);
        await button.ScaleTo(1, 100, Easing.Linear);
        
        await Navigation.PushAsync(new MenuPage());
    }

    public async static void ShowError(string message)
    {
        var errorDialog = new CustomErrorDialog(message);
        await Application.Current.MainPage.Navigation.PushModalAsync(errorDialog);
    }
}
