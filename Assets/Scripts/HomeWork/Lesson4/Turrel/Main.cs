using UnityEngine;

namespace Turrel
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Turrel _turrel;
        private TurrelController _turrelController;

        void Awake()
        {
            _turrelController = new TurrelController(_turrel);

        }

        void Update()
        {
            _turrelController.Execute();
        }
    }
}