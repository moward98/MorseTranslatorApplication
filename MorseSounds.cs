using System;
using System.Threading;

namespace MorseTranslator
{
    class MorseSound
    {
        private const int _frequency = 600;

        private const int _ditTime = 240;

        private int _duration;
        
        public int Duration { get { return _duration; } set { _duration = (value * _ditTime); } }

        public MorseSound(int duration)
        {
            Duration = duration;
        }

        public void Play()
        {
            Console.Beep(_frequency, this._duration);
            //Thread.Sleep(this._duration);
        }

    }

    class MorseSilence
    {
        private const int _ditTime = 240;

        private int _duration;

        public int Duration { get { return _duration; } set { _duration = (value * _ditTime); } }

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
