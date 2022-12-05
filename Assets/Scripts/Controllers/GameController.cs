using System;
using General;

namespace Controllers
{
    public class GameController : Singleton<GameController>
    {
        public const Difficulty DEFAULT_DIFFICULTY = Difficulty.Easy;
        
        private Difficulty currentDifficulty = DEFAULT_DIFFICULTY;
        private int maxDifficulties = 0;
        private int currentScore = 0;

        public delegate void DifficultyChanged(Difficulty newDifficulty);
        public static event DifficultyChanged OnGameDifficultyChanged;


        public Difficulty CurrentDifficulty
        {
            get { return currentDifficulty; }
            private set { currentDifficulty = value; }
        }

        public int CurrentScore
        {
            get { return currentScore; }
            private set { currentScore = value; }
        }

        #region UNITY_METHODS

        private void Start()
        {
            WindowController.OnAfterOpenWindow -= StartLevel;
            WindowController.OnAfterOpenWindow += StartLevel;
            
            maxDifficulties = Enum.GetValues(typeof(Difficulty)).Length;
        }

        #endregion

        public void IncreaseDifficulty()
        {
            CurrentDifficulty += 1;
            if ((int)CurrentDifficulty == maxDifficulties)
                CurrentDifficulty = 0;
            OnGameDifficultyChanged?.Invoke(CurrentDifficulty);
        }

        public void StoreScore(int score)
        {
            currentScore = score;
        }

        /// <summary>
        /// start the game and start timer.
        /// </summary>
        /// <param name="window"></param>
        private void StartLevel(WindowType window)
        {
            if (window != WindowType.Level) return;

            CurrentScore = 0;
            LevelController.Instance.Run();
        }
    }
}
