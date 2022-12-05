using TMPro;
using UnityEngine;

namespace View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtScore;

        public void DisplayScore(int scoreToDisplay)
        {
            txtScore.text = $"Score: {scoreToDisplay:D4}";
        }
    }
}
