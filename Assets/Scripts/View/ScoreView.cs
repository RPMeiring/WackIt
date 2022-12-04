using TMPro;
using UnityEngine;

namespace View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtScore;

        public void DisplayScore(int scoreToDisplay)
        {
            txtScore.text = string.Format("Score: {0:D4}", scoreToDisplay);
        }
    }
}
