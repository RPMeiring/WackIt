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
                if (OnBeforeCloseWindow != null) OnBeforeCloseWindow();
                
                windowView.Hide(windowView.CurrentlyOpenWindow);

                if (OnAfterCloseWindow != null) OnAfterCloseWindow();
            }

            if (OnBeforeOpenWindow != null) OnBeforeOpenWindow(nextWindow);
            
            windowView.Show(nextWindow);

            if (OnAfterOpenWindow != null) OnAfterOpenWindow(nextWindow);

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
