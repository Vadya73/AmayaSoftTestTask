using DG.Tweening;
using UnityEngine;

namespace CodeBase
{
    public class AnimatorController
    {
        public void PlayWrongAnimation(GameObject animationObject)
        {
            Vector3 originalPosition = animationObject.transform.position;
            DOTween.Sequence()
                .Append(animationObject.transform.DOMove(originalPosition + new Vector3(-0.1f, 0, 0), 0.2f))
                .Append(animationObject.transform.DOMove(originalPosition + new Vector3(0.1f, 0, 0), 0.2f))
                .Append(animationObject.transform.DOMove(originalPosition + new Vector3(0, 0, 0), 0.2f));
        }

        public void PlayCorrectAnimation(GameObject animationObject)
        {
            Vector3 originalScale = animationObject.transform.localScale;
            DOTween.Sequence()
                .Append(animationObject.transform.DOScale(originalScale + new Vector3(-0.1f, -0.1f, 0), 0.2f))
                .Append(animationObject.transform.DOScale(originalScale + new Vector3(0.1f, 0.1f, 0), 0.2f))
                .Append(animationObject.transform.DOScale(originalScale + new Vector3(0, 0, 0), 0.2f));
        }

        public void PlayStartAnimation(GameObject animationObject, Vector3 intermediateAnimationScale,
            Vector3 endAnimationScale)
        {
            DOTween.Sequence()
                .Append(animationObject.transform.DOScale(intermediateAnimationScale, 1f))
                .Append(animationObject.transform.DOScale(endAnimationScale, 1f));
        }
    }
}