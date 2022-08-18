using System;
using System.Collections.Generic;

using Random = UnityEngine.Random;

namespace BullsAndCows
{
    internal sealed class ViewModel : IViewModel
    {
        private string _number;
        private int _rightNumbersCount;
        private int _rightNumbersPosition;

        public event Action<Dictionary<int, int>> ContinueGame;
        public event Action Victory;

        public ViewModel(IModel model)
        {
            _number = model.Number;
            _rightNumbersCount = 0;
            _rightNumbersPosition = 0;
        }
        public void CompareNumber(string number)
        {
            if (number == _number)
            {
                Victory?.Invoke();
            }
            else 
            {
                ContinueGame?.Invoke(SetRightNumber(number));
            }
        }
        public Dictionary<int, int> SetRightNumber(string number) 
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            _rightNumbersCount = 0;
            _rightNumbersPosition = 0;

            string helper = number;

            for (int i = 0; i < _number.Length; i++) 
            {
                for (int j = 0; j < _number.Length; j++) 
                {
                    if (helper[i] == _number[j]) 
                    {
                        helper.Remove(i);
                        _rightNumbersCount++;
                    }
                }
            }
            for (int i = 0; i < _number.Length; i++)
            {
                if (number[i] == _number[i])
                {
                    _rightNumbersPosition++;
                }
            }
            result[_rightNumbersCount] = _rightNumbersPosition;

            return result;
        }
    }
}