using System;
using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private const int REFERENCE_HEIGHT_IN_UNITS = 1000;
        private const int Z_VALUE_IN_UNITS = -10;
        
        #region UNITY_METHODS
        
        private void Awake()
        {
            Initialize();
        }
        
        #endregion

        /// <summary>
        /// Calculates the orthographic size based on Screen ratio.
        /// Mimics the functionality of the canvas (camera height is always 1000).
        /// </summary>
        private void Initialize()
        {
            float ratio = (float)Screen.height / (float)Screen.width;
            int orthographicSize = Mathf.RoundToInt(REFERENCE_HEIGHT_IN_UNITS / ratio);
            Vector3 position = new Vector3(Mathf.RoundToInt(orthographicSize / 2f), REFERENCE_HEIGHT_IN_UNITS / 2f, Z_VALUE_IN_UNITS);

            Camera.main.orthographicSize = orthographicSize;
            Camera.main.transform.position = position;

        }
    }
}
