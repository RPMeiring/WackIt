using General;
using UnityEngine;

namespace Controllers
{
    public class IndexController : MonoBehaviour
    {
        #region SCENE

        public void BtnChangeDifficulty()
        {
            changeDifficulty();
        }

        /// <summary>
        /// Intended for attachment to button in Scene.
        /// </summary>
        public void BtnPlay()
        {
            startGame();
        }

        /// <summary>
        /// Intended for attachment to button in Scene.
        /// </summary>
        public void BtnHighScore()
        {
            checkScores();
        }

        #endregion

        private void changeDifficulty()
        {
            GameController.Instance.IncreaseDifficulty();
        }

        /// <summary>
        /// Go to score window.
        /// </summary>
        private void checkScores()
        {
            WindowController.Instance.GoToWindow(WindowType.HighScore);
        }

        /// <summary>
        /// Start playing main game.
        /// </summary>
        private void startGame()
        {
            WindowController.Instance.GoToWindow(WindowType.Level);
        }
    }
}