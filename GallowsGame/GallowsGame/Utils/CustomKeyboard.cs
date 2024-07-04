
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
    }
}
