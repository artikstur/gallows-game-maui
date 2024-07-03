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

        public static CustomKeyboard CreateKeyboard(EnterWordPage page)
        {
            CustomKeyboard keyboard = new CustomKeyboard();
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
                                TextColor = Colors.Black,
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                            },

                            new Image()
                            {
                                 HeightRequest = 68,
                                 WidthRequest = 68,
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
                    Button innerBtn = new Button()
                    {
                        FontSize = 30,
                        HeightRequest = 58,
                        WidthRequest = 58,
                        BackgroundColor = Colors.Transparent,
                        Text = symbol.ToString(),
                        TextColor = Colors.Black,
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
            return keyboard;
        }
    }
}
