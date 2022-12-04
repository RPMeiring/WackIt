using System;
using Controllers;
using General;
using UnityEngine.EventSystems;

namespace Core
{
    public class NormalMoleController : MoleController, IPointerDownHandler
    {
        private const int SCORE = 5;

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
                case Difficulty.Medium:
                case Difficulty.Hard:
                    GameController.Instance.AddScore(SCORE);
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