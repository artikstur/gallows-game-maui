using GallowsGame.Utils;
using Microsoft.Maui.Layouts;
using System.Runtime.CompilerServices;
using System.Text;

namespace GallowsGame.Pages;

public partial class GamePage : ContentPage
{
    private int coinCount = 3;
    private string hiddenWord;
    private string currentOpenedWord; //���������� �� ������ ������ �����
    private Label currentWord;
    private List<Image> gallowsImages;
    private int attempts;
    private int currentAttempts;
    private int currentIndex = 0;
    private string folderPath;
    private string _currentPlayer;
    private int _firstPlayerScores;
    private int _secondPlayerScores;
    private string whoWalksinRound;
    public GamePage(string userText)
    {
        this.currentOpenedWord = new string('_', userText.Length);
        this.hiddenWord = userText;

        InitializeComponent();

        SetPlayersScores();
        ChooseCurrentPlayer();

        CreateLayout();
    }

    private void SetPlayersScores()
    {
        _firstPlayerScores = UserDataStorage.FirstPlayer.WinRoundCount;
        _secondPlayerScores = UserDataStorage.SecondPlayer.WinRoundCount;
    }
    private void ChooseCurrentPlayer()
    {
        int currentRound = UserDataStorage.AllRoundsCount;
        if (currentRound % 2 != 0)
        {
            // ���� ����� ������, �� ���������� ������
            _currentPlayer = UserDataStorage.SecondPlayer.Name;
        }
        else
        {
            // ���� ����� ����, �� ���������� ������
            _currentPlayer = UserDataStorage.FirstPlayer.Name;
        }
    }

    private FlexLayout CreateTopBarLayout()
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

        var firstPlayerNameLabel = new Label()
        {
            FontFamily = "Maki-Sans",
            Margin = new Thickness(0, 11, 0, 0),
            HorizontalOptions = LayoutOptions.Center,
            Text = $"{UserDataStorage.FirstPlayer.Name}",
            FontSize = 40,
            TextColor = Colors.Navy
        };

        var secondPlayerNameLabel = new Label()
        {
            FontFamily = "Maki-Sans",
            Margin = new Thickness(0, 11, 0, 0),
            HorizontalOptions = LayoutOptions.Center,
            Text = $"{UserDataStorage.SecondPlayer.Name}",
            FontSize = 40,
            TextColor = Colors.Navy
        };

        var currentScoresLabel = new Label()
        {
            FontFamily = "Maki-Sans",
            Margin = new Thickness(0, 11, 0, 0),
            HorizontalOptions = LayoutOptions.Center,
            Text = $"{_firstPlayerScores} : {_secondPlayerScores}",
            FontSize = 40,
            TextColor = Colors.Navy
        };
        var firstPlayerIcon = new Image()
        {
            Source = "stalin_icon.png",
            WidthRequest = 50,
            HeightRequest = 50,
            Margin = new Thickness(5, 10, 5, 0),
        };

        var secondPlayerIcon = new Image()
        {
            Source = "lenin_icon.png",
            WidthRequest = 50,
            HeightRequest = 50,
            Margin = new Thickness(5, 10, 5, 0),
        };

        var currentScoresBox = new FlexLayout()
        {
            Children = { firstPlayerNameLabel, firstPlayerIcon, currentScoresLabel, secondPlayerIcon, secondPlayerNameLabel},
            AlignContent = FlexAlignContent.Center,
            Wrap = FlexWrap.Wrap,
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
            Children = { currentScoresBox, currentWord}
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
        FlexLayout.SetBasis(leftBarCenterBox, new FlexBasis(0.45f, true));
        FlexLayout.SetBasis(pauseBtn, new FlexBasis(0.33f, true));

        var topBar = new FlexLayout()
        {
            Children = { coinBox, leftBarCenterBox, pauseBtn },
            JustifyContent = FlexJustify.SpaceBetween,
            Direction = FlexDirection.Row,
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.FillAndExpand,
        };

        return topBar;
    }

    private List<Image> CreateGallowsImagesLayout(string path)
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
        {
            folderPath = PathMaker.GetFolderPath("12_attempts");
        }
        else
        {
            folderPath = PathMaker.GetFolderPath("14_attempts");
        }

    }

    private FlexLayout CreateCenterLayout()
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
            Text = "��������� - ",
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
    private void CreateLayout()
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
    private async void OnPauseButtonClicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        button.IsEnabled = false;
        try
        {
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            await Navigation.PushAsync(new MenuPage());
        }
        finally
        {
            button.IsEnabled = true;
        }
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


    private async void OnKeyboardButtonClicked(object sender, EventArgs e)
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

    private void CountAttempts()
    {
        if (hiddenWord.Length < 6)
            attempts = 10;
        else if (hiddenWord.Length == 6)
            attempts = 12;
        else attempts = 14;
    }

    private void DetermineOutcomeOfRound()
    {
        if (hiddenWord == currentOpenedWord)
        {  
            CheckForEnd(true);
        }
        else if (currentAttempts >= attempts)
        {
            CheckForEnd(false);
        }
    }
    private void SetDefaultValues()
    {
        UserDataStorage.FirstPlayer.WinRoundCount = 0;
        UserDataStorage.SecondPlayer.WinRoundCount = 0;
        UserDataStorage.AllRoundsCount = 1;
    }

    private async void CheckForEnd(bool isWin)
    {
        AddWinnerPoint(UserDataStorage.AllRoundsCount, isWin);
        UserDataStorage.AllRoundsCount += 1;

        if (UserDataStorage.FirstPlayer.WinRoundCount == 2 || UserDataStorage.SecondPlayer.WinRoundCount == 2)
        {
            int firstPlayerWinCount = UserDataStorage.FirstPlayer.WinRoundCount; // ������� ������� ������
            int secondPlayerWinCount = UserDataStorage.SecondPlayer.WinRoundCount; //������� ������� ������

            //��� ����������
            string winner;
            if (firstPlayerWinCount == 2)
            {
                winner = UserDataStorage.FirstPlayer.Name;
            }
            else
            {
                winner = UserDataStorage.SecondPlayer.Name;
            }

            // ����� ���� ����������� ��� ������ ����

            await ShowResult(new WinGameWindow(winner, firstPlayerWinCount, secondPlayerWinCount));

            // ��������
            SetDefaultValues();
        }
        else
        {
            var guesser = GetPlayers(UserDataStorage.AllRoundsCount);

            if (isWin)
            {
                await ShowResult(new WinRoundWindow(guesser));
            }
            else
            {
                await ShowResult(new LoseRoundWindow(guesser));
            }
        }
    }


    public string GetPlayers(int roundNumber)
    {
        // ���������� �������� ������ � ���������� ������ �� ������ ������ ������
        switch (roundNumber % 2)
        {
            case 1: 
                return UserDataStorage.FirstPlayer.Name;
            case 0: 
                return UserDataStorage.SecondPlayer.Name;
            default:
                throw new ArgumentException("����� ������ ������ ���� ������������� ����� ������");
        }
    }
    private void AddWinnerPoint(int playerNumber, bool isWin)
    {
        if (isWin)
        {
            if (playerNumber % 2 != 0)
            {
                UserDataStorage.SecondPlayer.WinRoundCount += 1;
            }
            else
            {
                UserDataStorage.FirstPlayer.WinRoundCount += 1;
            }
        }
        else
        {
            if (playerNumber % 2 != 0)
            {
                UserDataStorage.FirstPlayer.WinRoundCount += 1;
            }
            else
            {
                UserDataStorage.SecondPlayer.WinRoundCount += 1;
            }
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
                await Task.Delay(400);
                gallowsImages[currentIndex].IsVisible = true;
                currentIndex++;
            }
        }
        DetermineOutcomeOfRound();
    }

    private async Task ShowResult(Page window)
    {
        await Application.Current.MainPage.Navigation.PushModalAsync(window);
    }

    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
    }
} 