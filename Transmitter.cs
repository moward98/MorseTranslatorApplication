using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using static MorseTranslator.MorseLookup;
using static MorseTranslator.MorseSound;
using MorseTranslatorApplication;

namespace MorseTranslator
{
    // Interpret the user message, translate to Morse Code, then Transmit the message
    class Transmitter
    {
        // Create lookup dictionary for text to morse conversion
        private MorseLookup MorseLookupTable = new MorseLookup();        

        // Create the morse sounds needed to transmit message
        private MorseSound _dit = new MorseSound(1);
        private MorseSound _dah = new MorseSound(3);
        // silence between dits and dahs within same character
        private MorseSilence _intraCharSpace = new MorseSilence(1);
        // silence between characters within same word
        private MorseSilence _interCharSpace = new MorseSilence(2);
        // silence between words
        private MorseSilence _wordSpace = new MorseSilence(5);
        
        private string _opInput;
        // Operator Text Input
        public string OpInput { get { return _opInput; } set { _opInput = value; InputSplitter(); } }

        private char[] _splitInput;
        // User Input split into a charater array
        public char[] SplitInput { get { return _splitInput; } set { _splitInput = value; } }


        // Split User Input into character array
        private void InputSplitter(){SplitInput =  OpInput.ToCharArray();}

        // Convert each character to morse code then transmit the corresponding dits and dahs
        public MorseOutputText TransmitTextMessage()
        {
            List<char> morseList = new List<char>();

            // Read each character that was input by the user
            foreach (char c in SplitInput)
            {
               // Convert the character into it's corresponding list of dits and dahs
                foreach (char x in MorseLookupTable.Lookup(c))
                {
                    // Put a / for a space character, otherwise put the morse character
                    morseList.Add((x == ' ') ? '/' : x);
                }                

                Console.Write(' ');
                morseList.Add(' ');

            }

            MorseOutputText translation = new MorseOutputText(morseList);

            return translation;
        }

        public void TransmitSoundMessage()
        {
            // Read each character that was input by the user
            foreach (char c in SplitInput)
            {
               // Convert the character into it's corresponding list of dits and dahs
                foreach (char x in MorseLookupTable.Lookup(c))
                {
                    // Transmit the dit or dah
                    switch (x)
                    {
                        case '.':
                            this._dit.Play();
                            this._intraCharSpace.Play();
                            break;
                        case '-':
                            this._dah.Play();
                            this._intraCharSpace.Play();
                            break;
                        case ' ':
                            this._wordSpace.Play();
                            break;
                        default:
                            Console.WriteLine("Unexpected Input");
                            break;
                    }
                }                

                Console.Write(' ');
                this._interCharSpace.Play();

            }
        }
        
        public void TransmitTextAndSoundMessage()
        {
            // Read each character that was input by the user
            foreach (char c in SplitInput)
            {
               // Convert the character into it's corresponding list of dits and dahs
                foreach (char x in MorseLookupTable.Lookup(c))
                {
                    // Print a / for a space character, otherwise print the morse character
                    Console.Write((x == ' ') ? '/' : x);

                    // Transmit the dit or dah
                    switch (x)
                    {
                        case '.':
                            this._dit.Play();
                            this._intraCharSpace.Play();
                            break;
                        case '-':
                            this._dah.Play();
                            this._intraCharSpace.Play();
                            break;
                        case ' ':
                            this._wordSpace.Play();
                            break;
                        default:
                            Console.WriteLine("Unexpected Input");
                            break;
                    }
                }                

                Console.Write(' ');
                this._interCharSpace.Play();

            }
        }

    }

}
