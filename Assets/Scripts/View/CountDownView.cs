using System;
using Controllers;
using TMPro;
using UnityEngine;

namespace View
{
    public class CountDownView : MonoBehaviour
    {
        [SerializeField] private GameObject inputBlocker;
        [SerializeField] private TextMeshProUGUI txtTimer;

        public void DisplayCount(float count)
        {
            int time = Mathf.FloorToInt(count);
            txtTimer.text = $"{time:D2}";
        }
        
        public void Show()
        {
            inputBlocker.SetActive(true);
            txtTimer.gameObject.SetActive(true);
        }

        public void Hide()
        {
            inputBlocker.SetActive(false);
            txtTimer.gameObject.SetActive(false);
        }
    }
}