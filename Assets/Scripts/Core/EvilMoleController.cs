using System;
using Controllers;
using General;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class EvilMoleController : MonoBehaviour, IMoleHandler, IPointerDownHandler
    {
        private const int SCORE_PENALTY = -10;
        private const float TIME_PENALTY = -10f;

        [SerializeField] private MoleView moleView;
        
        private bool isHittable = false;

        #region UNITY_METHODS

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
                    string warningMsg = "EvilMole shouldn't have been hit in easy mode";
                    Debug.LogWarning(warningMsg);
                    break;
                case Difficulty.Medium:
                    LevelController.Instance.AddScore(SCORE_PENALTY);
                    isHittable = false;
                    moleView.Hit();
                    break;
                case Difficulty.Hard:
                    LevelController.Instance.AddScore(SCORE_PENALTY);
                    LevelController.Instance.AddTime(TIME_PENALTY);
                    isHittable = false;
                    moleView.Hit();
                    break;
                default:
                    break;
            }
        }
    }
}