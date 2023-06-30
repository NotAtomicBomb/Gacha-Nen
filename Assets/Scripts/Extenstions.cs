using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


namespace UnityExtensionMethods{
    /// <summary>
    /// A class for extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Attempts to load scene.
        /// </summary>
        public static void LoadScene(this SceneAsset scene)
        {
            try
            {
                SceneManager.LoadScene(scene.name);
            }
            catch (UnassignedReferenceException)
            {
                Debug.LogWarning($"Scene asset has not been assigned");
            }
        }
    }
}
