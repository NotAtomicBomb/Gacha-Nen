using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    SceneAsset playScene;

    [SerializeField]
    SceneAsset settingsScene;

    [SerializeField]
    GameObject buttonsContainer;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform button in buttonsContainer.transform){
            switch(button.name){
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


    void Play()
    {
        LoadScene(playScene);
    }

    void Settings()
    {
        LoadScene(settingsScene);
    }

    void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
            
    }

    void LoadScene(SceneAsset scene)
    {
        try
        {
        SceneManager.LoadScene(scene.name);
        }
        catch(UnassignedReferenceException)
        {
            Debug.LogWarning($"Scene asset has not been assigned");
        }
    }

}
