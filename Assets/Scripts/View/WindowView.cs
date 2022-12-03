using System;
using System.Collections.Generic;
using General;
using UnityEngine;

namespace View
{
    public class WindowView : MonoBehaviour
    {
        [Serializable]
        public struct WindowDefinition
        {
            public GameObject Window;
            public WindowType Type;
        }

        [SerializeField] private List<WindowDefinition> allWindowsScene;


        private Dictionary<WindowType, GameObject> windows;
        private WindowType currentlyOpenWindow = WindowType.None;
        
        public WindowType CurrentlyOpenWindow
        {
            get { return currentlyOpenWindow; }
        }

        #region UNITY_METHODS

        private void Awake()
        {
            buildDictionary();
        }

        #endregion

        /// <summary>
        /// Will show the given window if defined in the scene.
        /// Animation not implemented yet.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="instantOpen"></param>
        public void Show(WindowType window, bool instantOpen = true)
        {
            if (!windows.ContainsKey(window))
            {
                string warningMsg = string.Format("Window is not present in dictionary. Please make sure window is defined in the scene");
                Debug.LogWarning(warningMsg);
                return;
            }

            currentlyOpenWindow = window;
            
            if (instantOpen)
                windows[window].SetActive(true);
            else
            {
                windows[window].SetActive(true);
                string warningMsg = string.Format("Animations are not implemented yet, used force instantOpen for now");
                Debug.LogWarning(warningMsg);
            }
        }

        /// <summary>
        /// Will hide the given window if defined in the scene.
        /// Animation not implemented yet.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="instantClose"></param>
        public void Hide(WindowType window, bool instantClose = true)
        {
            if (!windows.ContainsKey(window))
            {
                string warningMsg = string.Format("Window is not present in dictionary. Please make sure window is defined in the scene");
                Debug.LogWarning(warningMsg);
                return; 
            }
            
            if (instantClose)
                windows[window].SetActive(false);
            else
            {
                windows[window].SetActive(false);
                string warningMsg = string.Format("Animations are not implemented yet, used force instantClose for now");
                Debug.LogWarning(warningMsg);
            }

            currentlyOpenWindow = WindowType.None;

        }
        
        /// <summary>
        /// Loops through all windows assigned in the scene and adds them to a dictionary for easy lookup.
        /// Also makes sure all windows are closed.
        /// </summary>
        private void buildDictionary()
        {
            windows = new Dictionary<WindowType, GameObject>();

            foreach (var w in allWindowsScene)
            {
                windows.Add(w.Type, w.Window);
                w.Window.SetActive(false);                      // making sure all windows are closed, no unnecessary windows are open.
            }
            
            allWindowsScene.Clear();                            // empty list.
            allWindowsScene.TrimExcess();                       // remove unused capacity.
        }
        
        
    }
}
