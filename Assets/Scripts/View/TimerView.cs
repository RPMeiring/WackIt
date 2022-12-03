using TMPro;
using UnityEngine;

namespace View
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtTimer;

        #region UNITY_METHODS

        private void Start()
        {

        }

        #endregion

        /// <summary>
        /// Displays the time in 00:00 format.
        /// </summary>
        /// <param name="timeToDisplay"></param>
        public void DisplayTime(float timeToDisplay)
        {
            // timeToDisplay += 1f;
            int minutes = Mathf.FloorToInt(timeToDisplay / 60);
            int seconds = Mathf.FloorToInt(timeToDisplay % 60);
            txtTimer.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        }
    }
}
