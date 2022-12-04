using UnityEngine;
using View;

namespace Controllers
{
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

        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreView.DisplayScore(score);
        }
    }
}
