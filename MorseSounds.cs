using System;
using System.Threading;

namespace MorseTranslator
{
    class MorseSound
    {
        private const int Frequency = 600;

        private const int DitTime = 240;

        private int _duration;
        
        public int Duration { get { return _duration; } set { _duration = (value * DitTime); } }

        public MorseSound(int duration)
        {
            Duration = duration;
        }

        public void Play()
        {
            Console.Beep(Frequency, this._duration);
            //Thread.Sleep(this._duration);
        }

    }

    class MorseSilence
    {
        private const int DitTime = 240;

        private int _duration;

        public int Duration { get { return _duration; } set { _duration = (value * DitTime); } }

        public MorseSilence(int duration)
        {
            Duration = duration;
        }

        public void Play()
        {
            Thread.Sleep(this._duration);
        }
    }

}
