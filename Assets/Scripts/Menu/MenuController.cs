using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityExtensionMethods;

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
        playScene.LoadScene();
    }

    /// <summary>
    /// Loads the settings scene
    /// </summary>
    void Settings()
    {
        settingsScene.LoadScene();
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
}
