using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace UnoGame.Functions
{
    public static class Function
    {
        public static string titleCase(string stringToTitleCase)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            //If the string is all capitals it will not be title cased.
            stringToTitleCase = stringToTitleCase.ToLower();
            stringToTitleCase = textInfo.ToTitleCase(stringToTitleCase);

            return stringToTitleCase;
        }
    }
}
