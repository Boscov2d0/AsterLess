using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public interface IViewModel
    {
        public event Action<Dictionary<int, int>> ContinueGame;
        public event Action Victory;

        public void CompareNumber(string number);
        public Dictionary<int, int> SetRightNumber(string number);
    }
}