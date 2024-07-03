using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Utils
{
    internal static class KeyboardBuilder
    {
        public static List<char> Symbols { get; private set; } = new List<char>
        {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };

        public static CustomKeyboard CreateKeyboard()
        {
            CustomKeyboard keyboard = new CustomKeyboard();
            foreach (var symbol in Symbols)
            {
                Grid keyboardButton = new Grid();
            }

            throw new NotImplementedException();
        }
    }
}
