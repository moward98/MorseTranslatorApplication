using System;
using System.Collections.Generic;
using System.Text;

namespace MorseTranslator
{
    class MorseLookup
    {
        // Create the Morse Lookup Dictionary 
        private Dictionary<char, List<char>> MorseLookupTable = InitLookup();

        // Lookup the character and return the morse list of dits and dahs
        public List<char> Lookup(char c)
        {
            try
            {
                return this.MorseLookupTable[c];
            }
            // Handle characters that don't exist in morse (!>* etc.)
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                return new List<char>("\0");
            }
           

        }

        private static Dictionary<char, List<char>> InitLookup()
        {
            Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>();


            // Create all of the Dictionary Keys
            char[] dictKeys = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', 
                                '2', '3', '4', '5', '6', '7', '8', '9', '0', ' '};

            List<List<char>> dictValues = new List<List<char>>();

            // Create the morse character list for the corresponding character key
            dictValues.Add(new List<char> { '.', '-' });            // a
            dictValues.Add(new List<char> { '-', '.', '.' });       // b
            dictValues.Add(new List<char> { '-', '.', '-', '.' });  // c  
            dictValues.Add(new List<char> { '-', '.', '.' });       // d
            dictValues.Add(new List<char> { '.' });                 // e
            dictValues.Add(new List<char> { '.', '.', '-', '.' });  // f
            dictValues.Add(new List<char> { '-', '-', '.' });       // g
            dictValues.Add(new List<char> { '.', '.', '.', '.', }); // h
            dictValues.Add(new List<char> { '.', '.' });            // i
            dictValues.Add(new List<char> { '.', '-', '-', '-' });  // j
            dictValues.Add(new List<char> { '-', '.', '-' });       // k
            dictValues.Add(new List<char> { '.', '-', '.', '.' });  // l
            dictValues.Add(new List<char> { '-', '-' });            // m
            dictValues.Add(new List<char> { '-', '.' });            // n
            dictValues.Add(new List<char> { '-', '-', '-' });       // o
            dictValues.Add(new List<char> { '.', '-', '-', '.' });  // p
            dictValues.Add(new List<char> { '-', '-', '.', '-' });  // q
            dictValues.Add(new List<char> { '.', '-', '.' });       // r
            dictValues.Add(new List<char> { '.', '.', '.' });       // s
            dictValues.Add(new List<char> { '-' });                 // t
            dictValues.Add(new List<char> { '.', '.', '-' });       // u
            dictValues.Add(new List<char> { '.', '.', '.', '-' });  // v
            dictValues.Add(new List<char> { '.', '-', '-' });       // w
            dictValues.Add(new List<char> { '-', '.', '.', '-' });  // x
            dictValues.Add(new List<char> { '-', '.', '-', '-' });  // y
            dictValues.Add(new List<char> { '-', '-', '.', '.' });  // z
            dictValues.Add(new List<char> { '.', '-', '-', '-', '-' }); // 1
            dictValues.Add(new List<char> { '.', '.', '-', '-', '-' }); // 2
            dictValues.Add(new List<char> { '.', '.', '.', '-', '-' }); // 3
            dictValues.Add(new List<char> { '.', '.', '.', '.', '-' }); // 4
            dictValues.Add(new List<char> { '.', '.', '.', '.', '.' }); // 5
            dictValues.Add(new List<char> { '-', '.', '.', '.', '.' }); // 6
            dictValues.Add(new List<char> { '-', '-', '.', '.', '.' }); // 7
            dictValues.Add(new List<char> { '-', '-', '-', '.', '.' }); // 8
            dictValues.Add(new List<char> { '-', '-', '-', '-', '.' }); // 9
            dictValues.Add(new List<char> { '-', '-', '-', '-', '-' }); // 0
            dictValues.Add(new List<char> { ' ' });                     // space between words

            // Populate the Morse Lookup Dictionary
            for (int i = 0; i < dictKeys.Length; i++)
            {
                dict.Add(dictKeys[i], dictValues[i]);
            }

            return dict;

        }


    }
}
