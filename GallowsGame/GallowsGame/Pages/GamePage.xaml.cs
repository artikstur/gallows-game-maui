using GallowsGame.Utils;
using Microsoft.Maui.Layouts;

namespace GallowsGame.Pages;

public partial class GamePage : ContentPage
{
    private int coinCount = 3;
    private string hiddenWord;
    private string currentOpenedWord; //отгаданное на данный момент слово
    public GamePage(string userText)
    {
        this.currentOpenedWord = new string('_', userText.Length);
        this.hiddenWord = userText;

        InitializeComponent();
        CreateLayout();
    }

    public FlexLayout CreateTopBarLayout()
    {
        var coinImage = new Image()
        {
            Margin = new Thickness(10, 11, 5, 10),
            Source = "coin.png",
            HeightRequest = 50,
            WidthRequest = 50,
        };

        var balanceLabel = new Label()
        {
            Text = coinCount.ToString(),
            FontSize = 50,
        };

        var coinBox = new FlexLayout()
        {
            Children = { coinImage, balanceLabel },
        };

        var currentWordClue = new Label()
        {
            Margin = new Thickness(0, 11, 0, 0),
            HorizontalOptions = LayoutOptions.Center,
            Text = "Слово:",
            FontSize = 40,
        };

        var currentWord = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
            Text = this.currentOpenedWord,
            FontSize = 50,
        };

        var leftBarCenterBox = new VerticalStackLayout()
        {
            Children = { currentWordClue, currentWord }
        };

        var pauseBtn = new ImageButton()
        {
            HorizontalOptions = LayoutOptions.End,
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(0, 4, 10, 0),
            Source = "pausebttn.png",
            HeightRequest = 80,
            WidthRequest = 80,
        };

        pauseBtn.Clicked += OnPauseButtonClicked;

        FlexLayout.SetBasis(coinBox, new FlexBasis(0.33f, true));
        FlexLayout.SetBasis(leftBarCenterBox, new FlexBasis(0.33f, true));
        FlexLayout.SetBasis(pauseBtn, new FlexBasis(0.33f, true));

        var topBar = new FlexLayout()
        {
            Children = { coinBox, leftBarCenterBox, pauseBtn },
            JustifyContent = FlexJustify.SpaceBetween,
            Direction = FlexDirection.Row,
            HeightRequest = 150,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        return topBar;
    }

    public Image CreateGallowsImageLayout()
    {
        var gallowsImage = new Image()
        {
            Margin = 30,
            Source = "gallow_concept.png",
        };

        return gallowsImage;
    }

    public FlexLayout CreateCenterLayout()
    {
        var gallowsImage = CreateGallowsImageLayout();
        FlexLayout.SetBasis(gallowsImage, new FlexBasis(1f, true));

        var leftCenterBox = new Grid()
        {
            Children = { gallowsImage },
        };

        var keyboardLayOut = CreateKeyBoardLayout(700);
        FlexLayout.SetBasis(gallowsImage, new FlexBasis(1f, true));

        var cluePriceLabel = new Label()
        {
            Text = "Подсказка - ",
            FontSize = 50,
        };

        var coinImage = new Image()
        {
            Margin = new Thickness(5, 14, 0, 0),
            Source = "coin.png",
            HeightRequest = 40,
            WidthRequest = 40,
        };

        var clueBox = new FlexLayout()
        {
            Margin = new Thickness(0, 30, 0, 0),
            Children = { cluePriceLabel, coinImage },
            HorizontalOptions = LayoutOptions.Center,
            AlignContent = FlexAlignContent.Start,
        };

        var rightCenterBox = new StackLayout()
        {
            Children = { keyboardLayOut, clueBox },
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Start,
        };

        var centerBox = new FlexLayout()
        {
            Margin = new Thickness(30, 0),
            Children = { leftCenterBox, rightCenterBox },
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        FlexLayout.SetBasis(leftCenterBox, new FlexBasis(0.5f, true));
        FlexLayout.SetBasis(rightCenterBox, new FlexBasis(0.5f, true));

        return centerBox;
    }
    public void CreateLayout()
    {
        var topBar = CreateTopBarLayout();
        var centerBox = CreateCenterLayout();

        var backgroundImage = new Image
        {
            Source = "background.png",
            Aspect = Aspect.AspectFill,
        };

        var MainContent = new StackLayout()
        {
            Children = { topBar, centerBox }
        };

        Content = new Grid
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children =
            {
                backgroundImage,
                MainContent,
            }
        };
    }
    public void OnPauseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MenuPage());
    }

    private StackLayout CreateKeyBoardLayout(int boxSize)
    {
        var keyboard = KeyboardBuilder.CreateKeyboard(this, OnKeyboardButtonClicked, OnClearButtonClicked, false);

        var keyboardLayout = new FlexLayout()
        {
            WidthRequest = 600,
            JustifyContent = FlexJustify.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        var keyboardBox = new StackLayout()
        {
            Children = { keyboardLayout },
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        foreach (var item in keyboard)
        {
            keyboardLayout.Children.Add(item);
        }

        keyboardLayout.Wrap = FlexWrap.Wrap;

        return keyboardBox;
    }

    public void OnKeyboardButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Colors.Aqua;
    }

    public void OnClearButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.BackgroundColor = Colors.Aqua;
    }
}