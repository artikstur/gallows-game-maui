using GallowsGame.Utils;
using Microsoft.Maui.Layouts;
using System.Text;

namespace GallowsGame.Pages;

public partial class GamePage : ContentPage
{
    private int coinCount = 3;
    private string hiddenWord;
    private string currentOpenedWord; //отгаданное на данный момент слово
    private Label currentWord;
    private List<Image> gallowsImages;
    private int attempts;
    private int currentAttempts;
    private int currentIndex = 0;
    private string folderPath;
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
            Margin = new Thickness(10, 3, 5, 10),
            Source = "coin.png",
            HeightRequest = 50,
            WidthRequest = 50,
        };

        var balanceLabel = new Label()
        {
            FontFamily = "Maki-Sans",
            Text = coinCount.ToString(),
            FontSize = 50,
            TextColor = Colors.Black
        };

        var coinBox = new FlexLayout()
        {
            Children = { coinImage, balanceLabel },
        };

        var currentWordClue = new Label()
        {
            FontFamily = "Maki-Sans",
            Margin = new Thickness(0, 11, 0, 0),
            HorizontalOptions = LayoutOptions.Center,
            Text = "Слово:",
            FontSize = 30,
            TextColor = Colors.Navy
        };

        currentWord = new Label()
        {
            FontFamily = "Maki-Sans",
            HorizontalOptions = LayoutOptions.Center,
            Text = currentOpenedWord,
            FontSize = 60,
            TextColor = Colors.Red,
            Margin = new Thickness(0, 10, 0, 0)
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

    public List<Image> CreateGallowsImagesLayout(string path)
    {
        List<ImageSource> imageSources = ImagesLoader.LoadFromFolder(path);

        List<Image> images = new List<Image>();

        foreach (var imageSource in imageSources)
        {
            var image = new Image
            {
                Source = imageSource
            };

            images.Add(image);
        }

        for (int i = 0; i < images.Count; i++)
        {
            images[i].IsVisible = false;
        }
        return images;

    }

    private void ChooseFolderPath()
    {
        if (hiddenWord.Length < 6)
        {
            folderPath = PathMaker.GetFolderPath("10_attempts");
        }
        else if (hiddenWord.Length == 6)
            folderPath = PathMaker.GetFolderPath("12_attempts");

        else folderPath = PathMaker.GetFolderPath("14_attempts");

    }

    public FlexLayout CreateCenterLayout()
    {
        ChooseFolderPath();

        gallowsImages = CreateGallowsImagesLayout(folderPath);

        foreach (var gallowsImage in gallowsImages)
        {
            FlexLayout.SetBasis(gallowsImage, new FlexBasis(1f, true));
        }

        var leftCenterBox = new Grid();

        foreach (var gallowsImage in gallowsImages)
        {
            leftCenterBox.Children.Add(gallowsImage);
        }

        var keyboardLayOut = CreateKeyBoardLayout(700);

        var cluePriceLabel = new Label()
        {
            FontFamily = "Maki-Sans",
            Text = "Подсказка - ",
            FontSize = 50,
            TextColor = Colors.Black
        };

        var coinImage = new Image()
        {
            Margin = new Thickness(5, 3, 0, 0),
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
    public async void OnPauseButtonClicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        await button.ScaleTo(1.2, 100, Easing.Linear);
        await button.ScaleTo(1, 100, Easing.Linear);

        await Navigation.PushAsync(new MenuPage());
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


    public async void OnKeyboardButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        button.IsEnabled = false;
        button.Background = Colors.Transparent;
        button.TextColor = Colors.Black;

        await button.ScaleTo(1.2, 100, Easing.Linear);
        await button.ScaleTo(1, 100, Easing.Linear);

        Grid parentGrid = (Grid)button.Parent;
        Image image = parentGrid.Children.OfType<Image>().FirstOrDefault();

       

        await GuessLetter(button.Text, image);
    }

    public void CountAttempts()
    {
        if (hiddenWord.Length < 6)
            attempts = 10;
        else if (hiddenWord.Length == 6)
            attempts = 12;
        else attempts = 14;
    }

    public void DetermineOutcomeOfRound()
    {

        if (hiddenWord == currentOpenedWord)
        {
            ShowResult(new WinRoundWindow());
        }
        else if (currentAttempts >= attempts)
        {
            ShowResult(new LoseRoundWindow());
        }
    }

    private async Task GuessLetter(string buttonText, Image image)
    {

        CountAttempts();

        if (hiddenWord.Contains(buttonText))
        {
            image.Source = "right_letter.png";

            StringBuilder sb = new StringBuilder(currentOpenedWord);
            int index = -1;

            while ((index = hiddenWord.IndexOf(buttonText, index + 1)) != -1)
            {
                sb[index] = buttonText[0];
            }
            currentOpenedWord = sb.ToString();
            currentWord.Text = currentOpenedWord;

            if (currentIndex != 0)
            {
                currentIndex--;
                currentAttempts--;
            }

            gallowsImages[currentIndex].IsVisible = false;

        }
        else
        {
            currentAttempts+=2;
            image.Source = "wrong_letter.png";
            gallowsImages[currentIndex].IsVisible = true;
            currentIndex++;
            if (currentIndex != attempts)
            {
                await Task.Delay(550);
                gallowsImages[currentIndex].IsVisible = true;
                currentIndex++;
            }
        }
        DetermineOutcomeOfRound();
    }



    public static void ShowResult(Page window)
    {
        Application.Current.MainPage.Navigation.PushModalAsync(window);
    }

    public void OnClearButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
    }

   
} 