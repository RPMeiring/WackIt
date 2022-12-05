using System;
using Data;
using General;
using TMPro;
using UnityEngine;
using View;

namespace Controllers
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private GameOverView gameOverView;
        
        private const string validChars = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
        private const char emptyChar = '\0';
        private const int charLimit = 3;
        
        [SerializeField] private TMP_InputField aliasInputField;

        #region UNITY_METHODS

        private void Awake()
        {
            // max 3 chars input for alias.
            aliasInputField.characterLimit = charLimit;
            aliasInputField.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
        }

        private void Start()
        {
            aliasInputField.onValidateInput += OnValidateInput;
        }

        private void OnEnable()
        {
            int score = GameController.Instance.CurrentScore;
            gameOverView.FormatScreen(score, HighScoreDataController.Instance.IsScoreNewHighScore(score));
        }

        #endregion

        #region SCENE

        public void BtnClose()
        {
            WindowController.Instance.GoToWindow(WindowType.Index);
        }

        public void BtnSave()
        {
            HighScoreData highScoreData = new HighScoreData
                { Alias = aliasInputField.text, Score = GameController.Instance.CurrentScore };
            HighScoreDataController.Instance.UpdateData(highScoreData);
            HighScoreDataController.Instance.SaveData();
            WindowController.Instance.GoToWindow(WindowType.HighScore);
        }

        #endregion
        
        /// <summary>
        /// Make sure all entries are uppercase.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charIndex"></param>
        /// <param name="addedChar"></param>
        /// <returns></returns>
        private char OnValidateInput(string text, int charIndex, char addedChar)
        {
            if (validChars.IndexOf(addedChar) != -1)
                return char.ToUpper(addedChar);
            else
                return emptyChar;
        }
    }
}