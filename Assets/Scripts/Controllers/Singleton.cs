using System;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Only 1 object of a specific type is allowed to exist in the scene at any given time.
    /// Meant for controllers which need to be accessible by different objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
	
        public static T Instance 
        {
	        get
	        {
		        if (_instance == null)
		        {
			        _instance = (T)FindObjectOfType(typeof(T), true);

			        if (FindObjectsOfType(typeof(T)).Length > 1)
			        {
				        string errorMsg =
					        string.Format(
						        "[Singleton] Instance of {0} already exists in scene. Restart scene or delete an instance",
						        typeof(T));
				        Debug.LogError(errorMsg);
				        return _instance;
			        }

			        if (_instance == null)
			        {
				        GameObject singleton = new GameObject();
				        _instance = singleton.AddComponent<T>();
				        singleton.name = string.Format("generated {0} ", typeof(T));
			        }
		        }
		        
		        return _instance;
	        }
        }

        private void OnDestroy ()
        {
	        _instance = null;
        }
    }
}
