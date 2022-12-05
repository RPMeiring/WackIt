using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class HighScoreEntryView : MonoBehaviour
    {
        [SerializeField] private Image imgBackground;
        [SerializeField] private TextMeshProUGUI txtRank;
        [SerializeField] private TextMeshProUGUI txtScore;
        [SerializeField] private TextMeshProUGUI txtAlias;

        /// <summary>
        /// Formats the highscore entry based on given parameters.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="score"></param>
        /// <param name="alias"></param>
        /// <param name="rankColor"></param>
        /// <param name="backgroundColor"></param>
        public void Format(int rank, int score, string alias, Color rankColor, Color backgroundColor)
        {
            txtRank.text = rank.ToString();
            txtRank.color = rankColor;
            txtScore.text = string.Format("{0:D4}", score);
            txtScore.color = rankColor;
            txtAlias.text = alias;
            txtAlias.color = rankColor;
            imgBackground.color = backgroundColor;
        }
    }
}