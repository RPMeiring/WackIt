using General;
using UnityEngine;

namespace Controllers
{
    public class LevelController : Singleton<LevelController>
    {
        private const float MAX_TIMER_IN_SECONDS_EASY = 90f;        
        private const float MAX_TIMER_IN_SECONDS_MEDIUM = 60f;
        private const float MAX_TIMER_IN_SECONDS_HARD = 60f;

        [SerializeField] private CountDownController countDownController;
        [SerializeField] private SpawnController spawnController;
        [SerializeField] private TimerController timerController;
        [SerializeField] private ScoreController scoreController;

        private bool isRunning = false;
        
        public bool IsRunning
        {
            get { return isRunning; }
            private set { isRunning = value; }
        }

        #region UNITY_METHODS

        private void Start()
        {
            TimerController.OnTimerRunsOut -= GameOver;
            TimerController.OnTimerRunsOut += GameOver;

            CountDownController.OnCountDownFinished -= StartLevel;
            CountDownController.OnCountDownFinished += StartLevel;
        }

        #endregion
        
        /// <summary>
        /// score will be added to score on screen.
        /// negative value decreases the score.
        /// </summary>
        /// <param name="scoreToAdd"></param>
        public void AddScore(int scoreToAdd)
        {
            scoreController.UpdateScore(scoreToAdd);
        }

        public void DeactivateSpawn(string id)
        {
            spawnController.RemoveHoleFromActiveList(id);
        }

        /// <summary>
        /// time will be added to timer.
        /// negative time to add decreases the time.
        /// </summary>
        /// <param name="timeToAdd"></param>
        public void AddTime(float timeToAdd)
        {
            timerController.UpdateTime(timeToAdd);
        }

        public void Run()
        {
            scoreController.ResetScore();
            timerController.InitializeTimer(DetermineTimer());
            spawnController.Initialize();
            countDownController.StartCountDown();
        }

        void StartLevel()
        {
            timerController.StartTimer();
            IsRunning = true;
        }

        private float DetermineTimer()
        {
            return GameController.Instance.CurrentDifficulty == Difficulty.Easy ? MAX_TIMER_IN_SECONDS_EASY : 
                (GameController.Instance.CurrentDifficulty == Difficulty.Medium ? MAX_TIMER_IN_SECONDS_MEDIUM : MAX_TIMER_IN_SECONDS_HARD); 
        }
        
        /// <summary>
        /// Clear Npc's, stop the game and go to game over screen
        /// </summary>
        private void GameOver()
        {
            IsRunning = false;
            GameController.Instance.StoreScore(scoreController.Score);
            spawnController.DeactivateAllHoles();
            WindowController.Instance.GoToWindow(WindowType.GameOver);
        }
    }
}