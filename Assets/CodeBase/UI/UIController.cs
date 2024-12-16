using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace CodeBase.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _loadingScreen;
        [SerializeField] private CanvasGroup _endGameScreen;
        [SerializeField] private Button _restartButton;
        
        private FadeInOutComponent _fadeComponent;

        [Inject]
        private void Construct(FadeInOutComponent fadeComponent)
        {
            _fadeComponent = fadeComponent;
        }
        public void ShowEndScreen()
        {
            _fadeComponent.FadeIn(_endGameScreen, 2f);
            _restartButton.interactable = true;
        }

        public void HideEndScreen()
        {
            _fadeComponent.FadeOut(_endGameScreen, 2f);
        }

        public void ShowLoadingScreen()
        {
            _fadeComponent.FadeIn(_loadingScreen, 2f);
        }

        public void HideLoadingScreen()
        {
            _fadeComponent.FadeOut(_loadingScreen, 2f);
        }
    }
}