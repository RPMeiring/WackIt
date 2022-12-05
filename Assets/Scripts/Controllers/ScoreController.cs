using UnityEngine;
using View;

namespace Controllers
{
    /// <summary>
    /// Keeps track of the score that the player gets.
    /// </summary>
    public class ScoreController : MonoBehaviour
    {
        private const int START_SCORE = 0;

        [SerializeField] private ScoreView scoreView;

        private int score;

        public int Score
        {
            get { return score; }
            private set { score = value; }
        }

        /// <summary>
        /// Score will be updated based on the score that needs to be added.
        /// </summary>
        /// <param name="scoreToAdd"></param>
        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreView.DisplayScore(score);
        }

        public void ResetScore()
        {
            score = START_SCORE;
            scoreView.DisplayScore(score);
        }
    }
}
