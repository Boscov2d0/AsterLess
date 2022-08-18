using UnityEngine;

namespace BullsAndCows
{
    internal sealed class Main : MonoBehaviour
    {
        [SerializeField] private GameView _gameView;
        [SerializeField] private PlayerView _playerView;

        private void Start()
        {
            var Model = new Model(CreateNumber());
            var ViewModel = new ViewModel(Model);

            _gameView.Initialize(ViewModel);
            _playerView.Initialize(ViewModel);
        }

        private string CreateNumber()
        {
            string _number = "";

            for (int i = 0; i < 4; i++)
            {
                int number = Random.Range(0, 10);
                _number += number;
            }
            Debug.Log(_number);
            return _number;
        }
    }
}