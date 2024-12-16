using UnityEngine;
using VContainer;

namespace CodeBase.UI
{
    public class RestartGameButtonObserver : MonoBehaviour
    {
        private GameController _gameController;

        [Inject]
        private void Construct(GameController gameController)
        {
            _gameController = gameController;
        }
        public void Restart()
        {
            Debug.Log("OnMouseDown");
            _gameController.RestartGame();
        }
    }
}
