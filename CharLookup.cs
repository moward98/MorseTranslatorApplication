using System;
using System.Collections.Generic;
using System.Text;

namespace MorseTranslator
{
    public class CharLookup
    {
        // Create the Morse Lookup Dictionary 
        Dictionary<string, char> _charLookupTable = InitLookup();

        // Lookup the character and return the morse list of dits and dahs
        public char Lookup(char[] key)
        {
            try
            {
                List<char> temp = new List<char>();

                foreach (char c in key)
                {
                    switch (c)
                    {
                        case '\0':
                            break;
                        default:
                            temp.Add(c);
                            break;
                    }
                }

                string LookupKey = new string(temp.ToArray());

                char _temp = _charLookupTable[LookupKey];

                return _temp;
            }
            // Handle characters that don't exist in morse (!>* etc.)
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                return '\0';
            }
           

        }

        private static Dictionary<string, char> InitLookup()
        {
            Dictionary<string, char> dict = new Dictionary<string, char>();

            // Create all of the Dictionary Keys
            char[] dictValues = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', 
                                '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '};

            List<string> dictKeys = new List<string>();

            // Create the morse character list for the corresponding character key
            dictKeys.Add(".-");     // a
            dictKeys.Add("-...");    // b
            dictKeys.Add("-.-.");   // c  
            dictKeys.Add("-..");    // d
            dictKeys.Add(".");      // e
            dictKeys.Add("..-.");   // f
            dictKeys.Add("--.");    // g
            dictKeys.Add("....");   // h
            dictKeys.Add("..");     // i
            dictKeys.Add(".---");   // j
            dictKeys.Add("-.-");    // k
            dictKeys.Add(".-..");   // l
            dictKeys.Add("--");     // m
            dictKeys.Add("-.");     // n
            dictKeys.Add("---");    // o
            dictKeys.Add(".--.");   // p
            dictKeys.Add("--.-");   // q
            dictKeys.Add(".-.");    // r
            dictKeys.Add("...");    // s
            dictKeys.Add("-");      // t
            dictKeys.Add("..-");    // u
            dictKeys.Add("...-");   // v
            dictKeys.Add(".--");    // w
            dictKeys.Add("-..-");   // x
            dictKeys.Add("-.--");   // y
            dictKeys.Add("--..");   // z
            dictKeys.Add(".----");  // 1
            dictKeys.Add("..---");  // 2
            dictKeys.Add("...--");  // 3
            dictKeys.Add("....-");  // 4
            dictKeys.Add(".....");  // 5
            dictKeys.Add("-....");  // 6
            dictKeys.Add("--...");  // 7
            dictKeys.Add("---..");  // 8
            dictKeys.Add("----.");  // 9
            dictKeys.Add("-----");  // 0
            dictKeys.Add(" ");                     // space between words

            // Populate the Morse Lookup Dictionary
            for (int i = 0; i < dictValues.Length; i++)
            {
                dict.Add(dictKeys[i], dictValues[i]);
            }

            return dict;

        }


    }
}
