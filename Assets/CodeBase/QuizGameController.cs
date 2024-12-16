using CodeBase.UI;
using UnityEngine;

namespace CodeBase
{
    public class QuizGameController : MonoBehaviour
    {
        [SerializeField] private QuizGame _currentLevel;
        [SerializeField] private QuizGame[] _allLevels;
        [SerializeField] private UIController _uiController;
        
        private void Start()
        {
            InitLevels();
            _allLevels[_allLevels.Length - 1].SetLastLevel();
        }

        public void InitLevels()
        {
            GenerateRandomGames();
                
            for (var i = 0; i < _allLevels.Length; i++)
            {
                var level = _allLevels[i];
                level.gameObject.SetActive(false);
            }

            if (_allLevels.Length > 0)
            {
                _currentLevel = _allLevels[0];
                _currentLevel.gameObject.SetActive(true);
            }
            
        }

        private void GenerateRandomGames()
        {
            foreach (QuizGame level in _allLevels)
                level.Generator.GenerateQuizGame();
        }

        public void ShowNextLevel()
        {
            if (_currentLevel == null) return;

            int currentIndex = System.Array.IndexOf(_allLevels, _currentLevel);

            if (currentIndex >= 0 && currentIndex < _allLevels.Length - 1)
            {
                _currentLevel.gameObject.SetActive(false);

                _currentLevel = _allLevels[currentIndex + 1];
                _currentLevel.gameObject.SetActive(true);
            }
        }

        public void CheckLastLevelCompleted()
        {
            if (_currentLevel.IsLastLevel)
            {
                _uiController.ShowEndScreen();
            }
        }
    }
}