using Controllers;
using TMPro;
using UnityEngine;

namespace View
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private GameObject scoreTitle;
        [SerializeField] private GameObject newHighScoreTitle;
        [SerializeField] private GameObject aliasInputField;
        [SerializeField] private GameObject closeButton;
        [SerializeField] private GameObject saveButton;
        [SerializeField] private TextMeshProUGUI txtScore;
        
        private bool isNewHighScore = true;
        
        #region UNITY_METHODS

        private void OnEnable()
        {
            FormatScreen();
        }

        #endregion

        /// <summary>
        /// Set correct fields based on getting a new high score.
        /// Show score.
        /// </summary>
        private void FormatScreen()
        {
            scoreTitle.SetActive(!isNewHighScore);
            newHighScoreTitle.SetActive(isNewHighScore);
            aliasInputField.SetActive(isNewHighScore);
            closeButton.SetActive(!isNewHighScore);
            saveButton.SetActive(isNewHighScore);

            int score = GameController.Instance.Score();
            txtScore.text = string.Format("{0:D4}",score);
        }
    }
}