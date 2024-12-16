using CodeBase.UI;
using UnityEngine;

namespace CodeBase
{
    public class QuizGame : MonoBehaviour
    {
        [SerializeField] private Cell _correctCell;
        [SerializeField] private QuizGameController _gameController;
        [SerializeField] private QuizGameGenerator _generator;
        [SerializeField] private QuizUIInteractor _quizUI;
        public QuizGameGenerator Generator => _generator;

        [SerializeField] private bool _isLastLevel;
        
        public bool IsLastLevel => _isLastLevel;

        private void OnEnable()
        {
            if (_correctCell != null)
                _quizUI.UpdateText(_correctCell);
        }


        public void CheckCorrectAnswer(Cell cell)
        {
            if (cell.Name == _correctCell.Name)
            {
                ExerciseComplete();
                ShowStar();
            }
        }

        private void ShowStar()
        {
            // Show Stars Particle
        }

        public void SetCorrectCell(Cell cell) => _correctCell = cell;

        public void SetLastLevel() => _isLastLevel = true;

        private void ExerciseComplete()
        {
            Debug.Log("Complete");
            if (_isLastLevel)
            {
                _gameController.CheckLastLevelCompleted();
                return;
            }
            
            _gameController.ShowNextLevel();
        }
    }
}