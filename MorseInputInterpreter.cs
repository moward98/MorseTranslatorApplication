using MorseTranslator;
using System;
using System.Collections.Generic;
using System.Text;


namespace MorseTranslatorApplication
{
    public class MorseInputInterpreter
    {
        private const int _offset = 250;

        private const int _ditTime = 250;

        private const int _dahTime = 2 * _ditTime;

        private const int _intraCharSpace = _ditTime;

        private const int _interCharSpace = _dahTime;

        private const int _wordSpace = 7 * _ditTime;

        public List<char> _inputBuffer = new List<char>();

        public List<List<char>> _packagedInput = new List<List<char>>();

        public CharLookup _charLookupTable = new CharLookup();

        public List<char> _decodedMorseInput = new List<char>();

        public char[] Package = new char[5];

        public void InputClassifier(bool pressed, float time)
        {
            if (pressed)
            {

                if(time < _dahTime)
                {
                    _inputBuffer.Add('.');
                }
                else
                {
                    _inputBuffer.Add('-');
                }

            }
            else
            {
                if (time <= _wordSpace && time >= _interCharSpace)
                {
                    _inputBuffer.Add('/');
                }
                else if (time >= _wordSpace)
                {
                    _inputBuffer.Add(' ');
                }
            }
        }

        public void PackageClassifiedInputs()
        {
            _inputBuffer.Add('/');

            int index = 0;

            foreach (char c in _inputBuffer)
            {
                switch (c)
                {
                    case '/':
                        index = 0;
                        _decodedMorseInput.Add(_charLookupTable.Lookup(Package));
                        
                        for(int i = 0; i <= 4; i++)
                        {
                            Package[i] = '\0';
                        }

                        break;
                    default:
                        Package[index] = c;
                        index++;
                        break;
                }
            }

            _inputBuffer.Clear();

        }

        public string DecodedMorse()
        {   
            string decodedString = new string(_decodedMorseInput.ToArray());
            _decodedMorseInput.Clear();

            return decodedString;

        }
    }
}
