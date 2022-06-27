using System;
using static MorseTranslator.Transmitter;
using  MorseTranslatorApplication;

namespace MorseTranslator
{
    class Program
    {
        static string InputRequest()
        {
            // Ask User for Input
            Console.WriteLine("Enter Message To Be Converted: ");
            // Return User Input and convert to all lower case 
            return Console.ReadLine().ToLower();
        }

        public static void TransmitTheMorse()
        {
            Transmitter morseTx = new Transmitter();
            // Get and Save User Input
            morseTx.OpInput = InputRequest();
            // Call Transmitter to Transmit 
            morseTx.TransmitTextAndSoundMessage();
        }
    }
}
