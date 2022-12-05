using General;
using UnityEngine;
using View;

namespace Controllers
{
    public class WindowController : Singleton<WindowController>
    {
        [SerializeField] private WindowView windowView;
        
        // ** ACTIONS AND DELEGATES ** //
        
        public delegate void BeforeOpenWindow(WindowType window);
        public delegate void BeforeCloseWindow();
        public delegate void AfterOpenWindow(WindowType window);
        public delegate void AfterCloseWindow();

        public static event BeforeOpenWindow OnBeforeOpenWindow;
        public static event BeforeCloseWindow OnBeforeCloseWindow;
        public static event AfterOpenWindow OnAfterOpenWindow;
        public static event AfterCloseWindow OnAfterCloseWindow;

        #region UNITY_METHODS

        private void Start()
        {
            openDefaultWindow();
        }

        #endregion

        /// <summary>
        /// Closes current opened window and opens the given window.
        /// Events are called for closing and opening.
        /// </summary>
        /// <param name="nextWindow"></param>
        public void GoToWindow(WindowType nextWindow)
        {
            if (windowView.CurrentlyOpenWindow != WindowType.None)
            {
                OnBeforeCloseWindow?.Invoke();
                
                windowView.Hide(windowView.CurrentlyOpenWindow);

                OnAfterCloseWindow?.Invoke();
            }

            OnBeforeOpenWindow?.Invoke(nextWindow);
            
            windowView.Show(nextWindow);

            OnAfterOpenWindow?.Invoke(nextWindow);

        }
        
        /// <summary>
        /// Open correct window at App start
        /// </summary>
        private void openDefaultWindow()
        {
            GoToWindow(WindowType.Index);
        }
        
        
        
        

    }
}
