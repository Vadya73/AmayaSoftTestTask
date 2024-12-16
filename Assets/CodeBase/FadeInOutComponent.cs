using DG.Tweening;
using UnityEngine;

namespace CodeBase
{
    public class FadeInOutComponent
    {
        private Tween _fadeTween;

        public void FadeIn(CanvasGroup canvasGroup, float duration)
        {
            Fade(canvasGroup, 1f, duration);
        }

        public void FadeOut(CanvasGroup canvasGroup, float duration)
        {
            Fade(canvasGroup, 0f, duration);
        }

        private void Fade(CanvasGroup canvasGroup, float endValue, float duration)
        {
            if (_fadeTween != null)
                _fadeTween.Kill(false);
            
            _fadeTween = canvasGroup.DOFade(endValue, duration);
        }
    }
}