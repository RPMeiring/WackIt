using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class MoleView : MonoBehaviour
    {
        private const float SPAWN_SCALE = 0f;
        private const float END_SCALE = 1f;
        private const float ANIMATION_DURATION = .3f;

        [SerializeField] private Image image;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color hitColor;

        private float maxShowDuration;

        private Action OnFinishAnimation; 
        
        public void Show(float showDuration, Action OnFinishAnimation)
        {
            image.color = defaultColor;
            maxShowDuration = showDuration;
            this.OnFinishAnimation = OnFinishAnimation;
            StartCoroutine(CoroutineShow());
        }

        public void Hit()
        {
            StopAllCoroutines();        // Make sure all animation stop.
            image.color = hitColor;
            StartCoroutine(Hide());
        }

        public IEnumerator Hide()
        {
            Vector3 startScale = transform.localScale;
            Vector3 endScale = new Vector3(SPAWN_SCALE, SPAWN_SCALE, SPAWN_SCALE);

            
            float elapsedTime = 0f;
            while (elapsedTime < ANIMATION_DURATION)
            {
                transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / ANIMATION_DURATION);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = endScale;
            
            OnFinishAnimation?.Invoke();
        }

        private IEnumerator CoroutineShow()
        {
            Vector3 startScale = new Vector3(SPAWN_SCALE, SPAWN_SCALE, SPAWN_SCALE);
            Vector3 endScale = new Vector3(END_SCALE, END_SCALE, END_SCALE);
            
            yield return StartCoroutine(animateShowHide(startScale, endScale));
            
        }

        private IEnumerator animateShowHide(Vector3 startScale, Vector3 endScale)
        {
            transform.localScale = startScale;

            float elapsedTime = 0f;
            while (elapsedTime < ANIMATION_DURATION)
            {
                transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / ANIMATION_DURATION);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = endScale;

            yield return new WaitForSeconds(maxShowDuration);

            elapsedTime = 0f;
            while (elapsedTime < ANIMATION_DURATION)
            {
                transform.localScale = Vector3.Lerp(endScale, startScale, elapsedTime / ANIMATION_DURATION);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = startScale;
            
            OnFinishAnimation?.Invoke();
        }
    }
}