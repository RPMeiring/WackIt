using System.Collections.Generic;
using Data;
using General;
using SaveLoad;
using UnityEngine;
using View;

namespace Controllers
{
    public class HighScoreController : MonoBehaviour
    {
        [SerializeField] private HighScoreView highScoreView;

        #region UNITY_METHODS

        private void OnEnable()
        {
            ClearHighScoreRanking();
            CreateHighScoreRanking();
        }

        #endregion

        #region SCENE

        /// <summary>
        /// Connected to HomeButton in HighScore gameObject in scene.
        /// </summary>
        public void BtnHome()
        {
            CloseHighScore();
        }

        #endregion

        /// <summary>
        /// Closes high score window en opens Index window.
        /// </summary>
        private void CloseHighScore()
        {
            WindowController.Instance.GoToWindow(WindowType.Index);
        }

        private void ClearHighScoreRanking()
        {
            highScoreView.ClearEntireHighScoreRanking();
        }

        private void CreateHighScoreRanking()
        {
            highScoreView.CreateEntireHighScoreRanking(HighScoreDataController.Instance.HighScoreDataList);
        }

        private void UpdateHighScoreRanking()
        {
            // to be implemented
        }



    }
}