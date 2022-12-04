using System;
using System.Collections.Generic;
using Core;
using General;
using UnityEngine;

namespace Controllers
{
    public class GameController : Singleton<GameController>
    {
        public const Difficulty DEFAULT_DIFFICULTY = Difficulty.Easy;
        private const float MAX_TIMER_IN_SECONDS_EASY = 90f;        
        private const float MAX_TIMER_IN_SECONDS_MEDIUM = 60f;
        private const float MAX_TIMER_IN_SECONDS_HARD = 60f;
        private const int MAX_HOLES_ACTIVE_EASY = 2;
        private const int MAX_HOLES_ACTIVE_MEDIUM = 5;
        private const int MAX_HOLES_ACTIVE_HARD = 9;

        [SerializeField] private HoleController[] allHolesInScene;
        [SerializeField] private TimerController timerController;
        [SerializeField] private ScoreController scoreController;
        
        private bool gameIsRunning = false;
        private Difficulty currentDifficulty = DEFAULT_DIFFICULTY;
        private int maxDifficulties;
        private int currentMaxHolesActive = 1;
        private Dictionary<string, HoleController> activeHoles = new Dictionary<string, HoleController>();

        public delegate void DifficultyChanged(Difficulty newDifficulty);

        public static event DifficultyChanged OnGameDifficultyChanged;

        public bool GameIsRunning
        {
            get { return gameIsRunning; }
            private set { gameIsRunning = value; }
        }

        public Difficulty CurrentDifficulty
        {
            get { return currentDifficulty; }
            private set { currentDifficulty = value; }
        }

        #region UNITY_METHODS

        private void Start()
        {
            WindowController.OnBeforeOpenWindow -= InitializeNewGame;
            WindowController.OnBeforeOpenWindow += InitializeNewGame;

            WindowController.OnAfterOpenWindow -= StartGame;
            WindowController.OnAfterOpenWindow += StartGame;

            TimerController.OnTimerRunsOut -= GameOver;
            TimerController.OnTimerRunsOut += GameOver;
            
            maxDifficulties = Enum.GetValues(typeof(Difficulty)).Length;
        }

        private void Update()
        {
            if (gameIsRunning)
            {
                if (activeHoles.Count < currentMaxHolesActive)
                {
                    int index = UnityEngine.Random.Range(0, allHolesInScene.Length);
                    HoleController selectedHole = allHolesInScene[index];
                    if (!activeHoles.ContainsKey(selectedHole.name))
                    {
                        activeHoles.Add(selectedHole.name, selectedHole);
                        selectedHole.Activate();
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Remove a specified Hole from the active list, so it can be selected on a later point again.
        /// </summary>
        /// <param name="currentHoleId"></param>
        public void RemoveHoleFromActiveList(string currentHoleId)
        {
            if (activeHoles.ContainsKey(currentHoleId))
                activeHoles.Remove(currentHoleId);
        }
        
        /// <summary>
        /// score will be added to score on screen.
        /// negative value decreases the score.
        /// </summary>
        /// <param name="scoreToAdd"></param>
        public void AddScore(int scoreToAdd)
        {
            scoreController.UpdateScore(scoreToAdd);
        }

        public int Score()
        {
            return scoreController.Score;
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

        public void IncreaseDifficulty()
        {
            CurrentDifficulty += 1;
            if ((int)CurrentDifficulty == maxDifficulties)
                CurrentDifficulty = 0;
            OnGameDifficultyChanged?.Invoke(CurrentDifficulty);
        }
        
        private void InitializeNewGame(WindowType window)
        {
            if (window != WindowType.Game) return;
            
            currentMaxHolesActive = CurrentDifficulty == Difficulty.Easy ? MAX_HOLES_ACTIVE_EASY : 
                (CurrentDifficulty == Difficulty.Medium ? MAX_HOLES_ACTIVE_MEDIUM : MAX_HOLES_ACTIVE_HARD);
            float startTime = CurrentDifficulty == Difficulty.Easy ? MAX_TIMER_IN_SECONDS_EASY : 
                (CurrentDifficulty == Difficulty.Medium ? MAX_TIMER_IN_SECONDS_MEDIUM : MAX_TIMER_IN_SECONDS_HARD); 
            timerController.InitializeTimer(startTime);
        }

        private void StartGame(WindowType window)
        {
            if (window != WindowType.Game) return;
            
            timerController.StartTimer();
            GameIsRunning = true;
        }

        private void GameOver()
        {
            GameIsRunning = false;
            WindowController.Instance.GoToWindow(WindowType.GameOver);
        }
    }
}
