using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase
{
    // Controller — это класс, который обрабатывает события одного объекта и вызывает команды у другого. (по GRASP) 
    public class GameController
    {
        [SerializeField] private QuizGameController _quizGameController;
        
        public void StartGame()
        {
            GenerateLevels();
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void GenerateLevels()
        {
            _quizGameController.InitLevels();
        }

    }
}