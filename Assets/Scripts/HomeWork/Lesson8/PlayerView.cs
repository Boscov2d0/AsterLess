using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BullsAndCows
{
    internal sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private InputField _inputFieldNumber;
        [SerializeField] private Text _gameNumber;
        [SerializeField] private GameObject _victoryPanel;
        [SerializeField] private Button _buttonEnterNubrer;
        [SerializeField] private Button _restartButton;

        private string number;

        private IViewModel _viewModel;

        public void Initialize(IViewModel ViewModel)
        {
            _viewModel = ViewModel;
            _viewModel.Victory += Victory;

            _victoryPanel.SetActive(false);

            _buttonEnterNubrer.onClick.AddListener(() => _viewModel.CompareNumber(_inputFieldNumber.text));
            _restartButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        }

        private void Victory()
        {
            _victoryPanel.SetActive(true);
            _gameNumber.text = _inputFieldNumber.text;
        }
        ~PlayerView()
        {
            _viewModel.Victory -= Victory;
        }
    }
}