using UnityEngine;
using View;

namespace Controllers
{
    /// <summary>
    /// Handles everything for countdown controller.
    /// Only needs to be started.
    /// </summary>
    public class CountDownController : MonoBehaviour
    {
        private const float COUNTDOWN_TIMER_TIME_IN_SECONDS = 3f;

        [SerializeField] private CountDownView countDownView;

        private float timer;
        private bool run = false;

        public delegate void CountDownFinished();

        public static event CountDownFinished OnCountDownFinished;


        #region UNITY_METHODS

        private void Update()
        {
            if (run)
            {
                if (timer > 0f)
                {
                    timer -= Time.deltaTime;
                    countDownView.DisplayCount(timer);
                }
                else
                {
                    timer = 0f;
                    countDownView.DisplayCount(timer);
                    run = false;
                    countDownView.Hide();
                    
                    OnCountDownFinished?.Invoke();
                }
            }
            
        }

        #endregion

        /// <summary>
        /// Start timer with Ui blocker.
        /// </summary>
        public void StartCountDown()
        {
            timer = COUNTDOWN_TIMER_TIME_IN_SECONDS;        // reset the count each time timer starts.
            countDownView.Show();
            run = true;
        }
    }
}