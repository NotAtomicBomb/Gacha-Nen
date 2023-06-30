using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    SceneAsset playScene;

    [SerializeField]
    SceneAsset settingsScene;

    [SerializeField]
    GameObject buttonsContainer;

    void Start()
    {
        foreach (Transform button in buttonsContainer.transform)
        {
            switch (button.name)
            {
                case "Play":
                    button.GetComponent<Button>().onClick.AddListener(Play);
                    break;
                case "Settings":
                    button.GetComponent<Button>().onClick.AddListener(Settings);
                    break;
                default:
                    button.GetComponent<Button>().onClick.AddListener(Exit);
                    break;
            }
        }
    }

    /// <summary>
    /// Loads the play scene
    /// </summary>
    void Play()
    {
        LoadScene(playScene);
    }

    /// <summary>
    /// Loads the settings scene
    /// </summary>
    void Settings()
    {
        LoadScene(settingsScene);
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    /// <summary>
    /// Loads the provided scene
    /// </summary>
    /// <param name="scene">Scene to switch to</param>
    void LoadScene(SceneAsset scene)
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
