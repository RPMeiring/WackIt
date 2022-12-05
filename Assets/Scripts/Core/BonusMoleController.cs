using Controllers;
using General;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class BonusMoleController : MoleController, IPointerDownHandler
    {
        private const int SCORE = 25;

        #region UNITY_METHODS

        public void OnPointerDown(PointerEventData eventData)
        {
            if (isHittable) Hit();
        }

        #endregion

        #region OVERRIDE_METHODS

        protected override void Hit()
        {
            switch (GameController.Instance.CurrentDifficulty)
            {
                case Difficulty.Easy:
                    string warningMsg = "BonusMole shouldn't have been hit in easy mode";
                    Debug.LogWarning(warningMsg);
                    break;
                case Difficulty.Medium:
                case Difficulty.Hard:
                    LevelController.Instance.AddScore(SCORE);
                    isHittable = false;
                    moleView.Hit();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}