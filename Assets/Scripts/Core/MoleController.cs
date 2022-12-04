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
        protected virtual void Hit() { }
    }
}