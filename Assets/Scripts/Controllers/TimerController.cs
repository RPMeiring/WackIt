using System;
using General;
using UnityEngine;
using View;

namespace Controllers
{
    /// <summary>
    /// Responsible for the level timer. Ha an event when timer runs out, most important for level controller
    /// </summary>
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private TimerView timerView;

        private float timer;
        private bool run = false;

        public delegate void TimerRunsOut();

        public static event TimerRunsOut OnTimerRunsOut;

        public float Timer
        {
            get { return timer; }
            private set { timer = value; }
        }

        #region UNITY_METHODS

        private void Update()
        {
            if (run)
            {
                if (Timer > 0f)
                {
                    Timer -= Time.deltaTime;
                    timerView.DisplayTime(Timer);
                }
                else
                {
                    Timer = 0f;
                    timerView.DisplayTime(Timer);
                    run = false;
                    
                    OnTimerRunsOut?.Invoke();
                }
            }
        }

        #endregion

        public void StartTimer()
        {
            run = true;
        }

        public void UpdateTime(float timeToAdd)
        {
            Timer += timeToAdd;
        }

        public void InitializeTimer(float startTime)
        {
            ResetTimer(startTime);
        }
        
        private void ResetTimer(float startTime)
        {
            Timer = startTime;
            timerView.DisplayTime(Timer);
        }

}
}
