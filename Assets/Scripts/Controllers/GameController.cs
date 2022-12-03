using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;

namespace Controllers
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private TimerController timerController;
        

        #region UNITY_METHODS

        private void Start()
        {
            WindowController.OnBeforeOpenWindow -= InitializeNewGame;
            WindowController.OnBeforeOpenWindow += InitializeNewGame;

            WindowController.OnAfterOpenWindow -= StartGame;
            WindowController.OnAfterOpenWindow += StartGame;

            TimerController.OnTimerRunsOut -= GameOver;
            TimerController.OnTimerRunsOut += GameOver;
        }

        #endregion

        private void InitializeNewGame(WindowType window)
        {
            if (window != WindowType.Game) return;
            
            timerController.InitializeTimer();
        }

        private void StartGame(WindowType window)
        {
            if (window != WindowType.Game) return;
            
            timerController.StartTimer();
        }

        private void GameOver()
        {
            WindowController.Instance.GoToWindow(WindowType.GameOver);
        }
    }
}
