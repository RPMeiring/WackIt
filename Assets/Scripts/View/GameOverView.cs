using Controllers;
using TMPro;
using UnityEngine;

namespace View
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private GameObject scoreTitle;
        [SerializeField] private GameObject newHighScoreTitle;
        [SerializeField] private TMP_InputField aliasInputField;
        [SerializeField] private GameObject closeButton;
        [SerializeField] private GameObject saveButton;
        [SerializeField] private TextMeshProUGUI txtScore;
        
        private bool isNewHighScore = true;
        
        #region UNITY_METHODS

        private void OnEnable()
        {
            int score = GameController.Instance.Score();
            isNewHighScore = HighScoreDataController.Instance.IsScoreNewHighScore(score);
            ResetTextInput();
            FormatScreen(score);
        }

        #endregion

        private void ResetTextInput()
        {
            aliasInputField.text = "";
        }

        /// <summary>
        /// Set correct fields based on getting a new high score.
        /// Show score.
        /// </summary>
        private void FormatScreen(int score)
        {
            scoreTitle.SetActive(!isNewHighScore);
            newHighScoreTitle.SetActive(isNewHighScore);
            aliasInputField.gameObject.SetActive(isNewHighScore);
            closeButton.SetActive(!isNewHighScore);
            saveButton.SetActive(isNewHighScore);

            txtScore.text = string.Format("{0:D4}",score);
        }
    }
}