using System;
using Controllers;
using General;
using TMPro;
using UnityEngine;

namespace View
{
    public class IndexView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI txtDifficulty;

        #region UNITY_METHODS

        private void Start()
        {
            GameController.OnGameDifficultyChanged -= updateTextDifficultyButton;
            GameController.OnGameDifficultyChanged += updateTextDifficultyButton;
            
            updateTextDifficultyButtonToDefault();
        }

        #endregion

        private void updateTextDifficultyButtonToDefault()
        {
            txtDifficulty.text = GameController.DEFAULT_DIFFICULTY.ToString();
        }
        
        private void updateTextDifficultyButton(Difficulty newDifficulty)
        {
            txtDifficulty.text = newDifficulty.ToString();
        }
    }
}