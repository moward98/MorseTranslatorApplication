using System;
using System.Collections.Generic;
using System.Text;

namespace MorseTranslatorApplication
{
    public class MorseOutputText
    {
        public List<char> MorseText;
        public MorseOutputText(List<char> outputText)
        {
            MorseText = outputText;
        }

        public char GetNextChar()
        {
            char temp = MorseText[0];
            MorseText.RemoveAt(0);
            return temp;
        }

    }


}
