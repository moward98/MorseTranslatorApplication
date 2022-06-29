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
using System.Diagnostics;
//using Utilities;
//using System.Windows.Forms;


namespace MorseTranslatorApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Transmitter _morseTx = new Transmitter();

        private Stopwatch _pressedStopwatch = new Stopwatch();

        private Stopwatch releasedStopwatch = new Stopwatch();

        private float _timeReleased = 0F;
        private float _timePressed = 0F;

        private bool _morseInputEnabled = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextToMorse_Click(object sender, RoutedEventArgs e)
        {
            InputInstr.Text = "Enter Text To Translate to Morse Below:";
            InputInstr.Visibility = Visibility.Visible;
            InputTextBorder.Visibility = Visibility.Visible;
            PrintMorseButton.Visibility = Visibility.Visible;
            PlayMorseButton.Visibility = Visibility.Visible;

            _morseInputEnabled = false;
        }

        private void MorseToText_Click(object sender, RoutedEventArgs e)
        {
            InputInstr.Text = "Click and tap M key on keyboard to input morse";
            MorseInField.Visibility = Visibility.Visible;
            InputInstr.Visibility = Visibility.Visible;
            InputTextBorder.Visibility = Visibility.Hidden;
            PrintMorseButton.Visibility = Visibility.Hidden;
            PlayMorseButton.Visibility = Visibility.Hidden;

            _morseInputEnabled = true;
        }

        private void PrintMorse_Click(object sender, RoutedEventArgs e)
        {
            // Get and Save User Input
            _morseTx.OpInput = InputRequest();

            PrintMorseButton.IsEnabled = false;           
            PlayMorseButton.IsEnabled = false;           
            MorseOutputLabel.Text = null;
            PrintMorse();
        }

        private void PlayMorse_Click(object sender, RoutedEventArgs e)
        {
            // Get and Save User Input
            _morseTx.OpInput = InputRequest();

            PrintMorseButton.IsEnabled = false;
            PlayMorseButton.IsEnabled = false;

            PlayMorse();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.M && _morseInputEnabled)
            {
                if (releasedStopwatch.IsRunning)
                {
                    releasedStopwatch.Stop();
                    _timeReleased = releasedStopwatch.ElapsedMilliseconds;
                    releasedStopwatch.Reset();
                }

                if (!_pressedStopwatch.IsRunning)
                {
                    _pressedStopwatch.Start();
                }

            }
        }

        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.M && _morseInputEnabled)
            {
                if (_pressedStopwatch.IsRunning)
                {
                    _pressedStopwatch.Stop();
                    _timePressed = _pressedStopwatch.ElapsedMilliseconds;
                    _pressedStopwatch.Reset();
                }

                if (!releasedStopwatch.IsRunning)
                {
                    releasedStopwatch.Start();
                }
            }
        }

        private void PlayMorse()
        {
            Thread morseDisplaythread = new Thread(() => SoundOutput());
            morseDisplaythread.Start();
        }

        private void SoundOutput()
        {
            _morseTx.TransmitSoundMessage();
        }

        public string InputRequest()
        {
            // Read text that user has input into the text box
            return InputText.Text;
        }

        private void PrintMorse()
        {
            // Call Transmitter to Transmit 
            MorseOutputText morseTranslation = _morseTx.TransmitTextMessage();

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
