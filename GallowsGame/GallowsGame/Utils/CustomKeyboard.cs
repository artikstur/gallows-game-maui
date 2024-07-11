
using System.Collections;

namespace GallowsGame.Utils
{
    internal class CustomKeyboard : IEnumerable<Grid>
    {
        public List<Grid> Buttons { get; } = new List<Grid>();
        public IEnumerator<Grid> GetEnumerator()
        {
            foreach (Grid button in Buttons)
            {
                yield return button;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ChangeButtonImage(char letter)
        {
            foreach (var buttonGrid in Buttons)
            {
                foreach (var element in buttonGrid.Children)
                {
                    if (element is Button button && button.Text == letter.ToString())
                    {
                        foreach (var innerElement in buttonGrid.Children)
                        {
                            if (innerElement is Image image)
                            {
                                image.Source = "right_letter.png";
                            }
                        }

                        button.IsEnabled = false;
                        button.Background = Colors.Transparent;
                        button.TextColor = Colors.Black;
                        return;


                    }
                }
            }
        }
    }
}
