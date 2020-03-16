using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using UnoGame.Cards;

namespace UnoGame.Functions
{
    public static class Function
    {
        public static string titleCase(string stringToTitleCase)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            stringToTitleCase = stringToTitleCase.ToLower();
            stringToTitleCase = textInfo.ToTitleCase(stringToTitleCase);

            return stringToTitleCase;
        }

    }
}
