using GallowsGame.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Utils
{
    internal static class KeyboardBuilder
    {
        public static List<char> Symbols { get; private set; } = new List<char>
        {
            ' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', ' ', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };

        private static HashSet<char> vowels = new HashSet<char> { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };
        public static EnterWordPage CurrentPage { get; private set; }
        public static CustomKeyboard CreateKeyboard(EnterWordPage page)
        {
            CustomKeyboard keyboard = new CustomKeyboard();
            CurrentPage = page;
            foreach (var symbol in Symbols)
            {
                if (symbol == ' ')
                {
                    var button = new Grid
                    {
                        Children =
                        {
                            new Button
                            {
                                FontSize = 30,
                                HeightRequest = 58,
                                WidthRequest = 58,
                                BackgroundColor = Colors.Transparent,
                                Text = symbol.ToString(),
                                TextColor = Colors.Navy,
                                FontFamily = "Maki-Sans",
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                            },

                            new Image()
                            {
                                 HeightRequest = 72,
                                 WidthRequest = 72,
                                 Source = "letter_button.png",
                                 Margin = 4,
                            }
                        },
                        Opacity = 0,
                    };
                    keyboard.Buttons.Add(button);
                }
                else
                {
                    var textColor = vowels.Contains(symbol) ? Colors.Red : Colors.Navy;

                    Button innerBtn = new Button()
                    {
                        FontSize = 30,
                        HeightRequest = 58,
                        WidthRequest = 58,
                        FontFamily = "Maki-Sans",
                        BackgroundColor = Colors.Transparent,
                        Text = symbol.ToString(),
                        TextColor = textColor,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };

                    innerBtn.Clicked += page.OnKeyboardButtonClicked;
                    var button = new Grid
                    {
                        Children =
                        {
                            new Image()
                            {
                                 HeightRequest = 68,
                                 WidthRequest = 68,
                                 Source = "letter_button.png",
                                 Margin = 4,
                            },
                            innerBtn,
                        }
                    };

                    keyboard.Buttons.Add(button);
                }
            }

            keyboard.Buttons.Add(CreateBackSpaceBtn());

            return keyboard;
        }


        private static Grid CreateBackSpaceBtn()
        {
            var backspaceInnerButton = new Button
            {
                FontSize = 30,
                HeightRequest = 58,
                WidthRequest = 58,
                BackgroundColor = Colors.Transparent,
                TextColor = Colors.Navy,
                FontFamily = "Maki-Sans",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            backspaceInnerButton.Clicked += CurrentPage.OnClearButtonClicked;

            var backspaceButton = new Grid
            {
                Children =
                        {
                            new Image()
                            {
                                 HeightRequest = 72,
                                 WidthRequest = 72,
                                 Source = "backspace_bttn.png",
                                 Margin = 4,
                            },

                            backspaceInnerButton,
                        },
            };

            return backspaceButton;
        }
    }
}
