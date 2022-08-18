using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BullsAndCows
{
    internal sealed class GameView : MonoBehaviour
    {
        [SerializeField] private Text _rightNumbersCount;
        [SerializeField] private Text _rightNumbersPosition;
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private Button _continueButton;

        private string _number;

        public string Number { get => _number; set => _number = value; }

        private IViewModel _viewModel;

        public void Initialize(IViewModel ViewModel)
        {
            _viewModel = ViewModel;
            _viewModel.ContinueGame += ShowResult;

            _continueButton.onClick.AddListener(ContinueGame);

            _resultPanel.SetActive(false);
        }

        private void ShowResult(Dictionary<int, int> dictionary)
        {
            _resultPanel.SetActive(true);

            foreach (var item in dictionary)
            {
                _rightNumbersCount.text = item.Key.ToString();
                _rightNumbersPosition.text = item.Value.ToString();
            }
        }
        private void ContinueGame() 
        {
            _resultPanel.SetActive(false);
        }
        ~GameView()
        {
            _viewModel.ContinueGame -= ShowResult;
        }
    }
}