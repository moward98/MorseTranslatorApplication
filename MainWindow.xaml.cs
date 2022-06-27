using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MorseTranslator;
using System.Timers;


namespace MorseTranslatorApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Transmitter morseTx = new Transmitter();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TextToMorse_Click(object sender, RoutedEventArgs e)
        {
            InputInstr.Visibility = Visibility.Visible;
            InputTextBorder.Visibility = Visibility.Visible;
            PrintMorseButton.Visibility = Visibility.Visible;
            PlayMorseButton.Visibility = Visibility.Visible;
        }
        private void MorseToText_Click(object sender, RoutedEventArgs e)
        {
            InputInstr.Visibility = Visibility.Hidden;
            InputTextBorder.Visibility = Visibility.Hidden;
            PrintMorseButton.Visibility = Visibility.Hidden;
            PlayMorseButton.Visibility = Visibility.Hidden;
        }
        private void PrintMorse_Click(object sender, RoutedEventArgs e)
        {
            // Get and Save User Input
            morseTx.OpInput = InputRequest();

            PrintMorseButton.IsEnabled = false;           
            PlayMorseButton.IsEnabled = false;           
            Console.WriteLine("Morse to Text was selected");
            MorseOutputLabel.Text = null;
            PrintMorse();
        }
        private void PlayMorse_Click(object sender, RoutedEventArgs e)
        {
            // Get and Save User Input
            morseTx.OpInput = InputRequest();

            PrintMorseButton.IsEnabled = false;
            PlayMorseButton.IsEnabled = false;

            PlayMorse();
            
        }

        private void PlayMorse()
        {
            morseTx.TransmitSoundMessage();
        }

        public string InputRequest()
        {
            // Read text that user has input into the text box
            return InputText.Text;
        }

        private void PrintMorse()
        {
            // Call Transmitter to Transmit 
            MorseOutputText morseTranslation = morseTx.TransmitTextMessage();

            Thread morseDisplaythread = new Thread(() => RefreshOutput(morseTranslation));
            morseDisplaythread.Start();
        }

        public void RefreshOutput(MorseOutputText morseOutput)
        {
            while (morseOutput.MorseText.Count != 0)
            {
                this.Dispatcher.Invoke(() =>
                {
                    MorseOutputLabel.Text += morseOutput.GetNextChar();
                });

                Thread.Sleep(250);
            }

            this.Dispatcher.Invoke(() =>
            {
                PrintMorseButton.IsEnabled = true;
                PlayMorseButton.IsEnabled = true;
            });

        }
    }
}
