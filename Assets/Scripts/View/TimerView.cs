using TMPro;
using UnityEngine;

namespace View
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtTimer;

        /// <summary>
        /// Displays the time in 00:00 format.
        /// </summary>
        /// <param name="timeToDisplay"></param>
        public void DisplayTime(float timeToDisplay)
        {
            // timeToDisplay += 1f;
            int minutes = Mathf.FloorToInt(timeToDisplay / 60);
            int seconds = Mathf.FloorToInt(timeToDisplay % 60);
            txtTimer.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }
}
