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

        /// <summary>
        /// Set correct fields based on getting a new high score.
        /// Show score.
        /// </summary>
        public void FormatScreen(int score, bool isNewHighScore)
        {
            if (isNewHighScore)
                ResetAliasInput();
            
            scoreTitle.SetActive(!isNewHighScore);
            newHighScoreTitle.SetActive(isNewHighScore);
            aliasInputField.gameObject.SetActive(isNewHighScore);
            closeButton.SetActive(!isNewHighScore);
            saveButton.SetActive(isNewHighScore);

            txtScore.text = $"{score:D4}";
        }

        private void ResetAliasInput()
        {
            aliasInputField.text = "";
        }
    }
}