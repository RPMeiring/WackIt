using System;
using Controllers;
using Core.Interface;
using General;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    /// <summary>
    /// Special mole for extra points.
    /// </summary>
    public class BonusMoleController : MonoBehaviour, IMoleHandler, IPointerDownHandler
    {
        private const int SCORE = 25;

        [SerializeField] private MoleView moleView;
        
        private bool isHittable = false;

        #region UNITY_METHODS

        /// <summary>
        /// Event for when user clicks on this object.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (isHittable) Hit();
        }

        #endregion
        
        public void Spawn(float showDuration, Action OnFinishAnimation)
        {
            gameObject.SetActive(true);
            isHittable = true;
            moleView.Show(showDuration, OnFinishAnimation);
        }

        public void DeSpawn()
        {
            isHittable = false;
            moleView.ForceHideNoAnimation();
            gameObject.SetActive(false);
        }
        
        public void Hit()
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
    }
}