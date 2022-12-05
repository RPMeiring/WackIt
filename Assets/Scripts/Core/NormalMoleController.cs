using System;
using Controllers;
using Core.Interface;
using General;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    /// <summary>
    /// Normal mole with low score amount.
    /// </summary>
    public class NormalMoleController : MonoBehaviour, IMoleHandler, IPointerDownHandler
    {
        private const int SCORE = 5;
        
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