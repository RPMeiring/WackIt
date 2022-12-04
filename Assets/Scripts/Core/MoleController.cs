using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class MoleController : MonoBehaviour
    {
        [SerializeField] protected MoleView moleView;
        
        protected bool isHittable = false;
        
        public virtual void Spawn(float showDuration) { }
        protected virtual void Hit() { }
    }
}