using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase
{
    public class Cell : MonoBehaviour
    {
        [FormerlySerializedAs("_quizGameController")] [SerializeField] private QuizGame _quizGame;
        [SerializeField] private AnimatorController _animator;
        [SerializeField] private string _name;
        [SerializeField] private SpriteRenderer _mainSprite;
        [SerializeField] private SpriteRenderer _backgroundSprite;
        [SerializeField] private SpriteRenderer _frameSprite;
        [SerializeField] private bool _isCorrect = false;
        [Space] 
        [SerializeField] private Vector3 _startAnimationScale = new Vector3(0.1f, 0.1f, 0.1f);
        [SerializeField] private Vector3 _intermediateAnimationScale = new Vector3(1.1f, 1.1f, 1.1f);
        [SerializeField] private Vector3 _endAnimationScale = new Vector3(1f, 1f, 1f);
        public bool IsCorrect => _isCorrect;
        public string Name => _name;
        private bool _canClicked = true;

        public void Construct(string name,Sprite mainSprite, Vector3 defaultRotation, Vector3 defaultScale, 
            Color backgroundSprite, Color frameSprite, QuizGame quizGame, AnimatorController animatorController)
        {
            _name = name;
            _mainSprite.sprite = mainSprite;
            _backgroundSprite.color = backgroundSprite;
            _frameSprite.color = frameSprite;
            _mainSprite.transform.localRotation = Quaternion.Euler(defaultRotation);
            _mainSprite.transform.localScale = defaultScale;
            _quizGame = quizGame;
            _animator = animatorController;
        }

        private void Start()
        {
            transform.localScale = _startAnimationScale;
            _animator.PlayStartAnimation(this.gameObject, _intermediateAnimationScale, _endAnimationScale);
        }

        private void OnMouseDown()
        {
            if (!_canClicked)
                return;

            ClickReload();
            
            if (CheckCorrectCell()) return;
            
            _animator.PlayWrongAnimation(this.gameObject);
        }

        private bool CheckCorrectCell()
        {
            if (_isCorrect)
            {
                _animator.PlayCorrectAnimation(this.gameObject);
                DOVirtual.DelayedCall(1f, () => _quizGame.CheckCorrectAnswer(this));
                return true;
            }

            return false;
        }

        private void ClickReload()
        {
            _canClicked = false;
            DOVirtual.DelayedCall(1f, () => _canClicked = true);
        }

        public void SetCorrect() => _isCorrect = true;
    }
}
