using System;
using General;

namespace Controllers
{
    /// <summary>
    /// Responsible for keep track of variables that have a wider responsibility than just for the level.
    /// Ex. game difficulty and score need to be accessed on index screen and gameoverscreen.
    /// </summary>
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

        /// <summary>
        /// Game difficulty is stored so we can access it later when needed.
        /// Will only reset on appstart. Isn't saved.
        /// </summary>
        public void IncreaseDifficulty()
        {
            CurrentDifficulty += 1;
            if ((int)CurrentDifficulty == maxDifficulties)
                CurrentDifficulty = 0;
            OnGameDifficultyChanged?.Invoke(CurrentDifficulty); // event that notifies everyone that depends on a difficulty change and subscribed to event.
        }

        /// <summary>
        /// Level score is stored so we can access it later on if needed.
        /// Will be reset each time a level is started.
        /// </summary>
        /// <param name="score"></param>
        public void StoreScore(int score)
        {
            currentScore = score;
        }

        /// <summary>
        /// starts the level and resets the current score.
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
