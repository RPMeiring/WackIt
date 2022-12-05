using System;
using UnityEngine;

namespace Core
{
    public class MoleController : MonoBehaviour
    {
        [SerializeField] protected MoleView moleView;
        
        protected bool isHittable = false;

        public void Spawn(float showDuration, Action OnFinishAnimation)
        {
            isHittable = true;
            moleView.Show(showDuration, OnFinishAnimation);
        }

        public void Despawn()
        {
            isHittable = false;
            moleView.ForceHideNoAnimation();
        }
        
        protected virtual void Hit() { }
    }
}