using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum SceneState
{
    Title,
    Play, 
    GoodEnd,
    BadEnd,
    Credits, 
    GameRestart
}
public class SceneSwitchManager : MonoBehaviour
{
    public static SceneState scene;

    Scene currentscene;
    void Start()
    {
        scene = SceneState.Title;
        DontDestroyOnLoad(gameObject);

        currentscene = SceneManager.GetActiveScene();
    }

    void Update()
    {
       if (Input.GetKey(KeyCode.R))
        {
            scene = SceneState.GameRestart;
        } 
    }

    void SceneStateManager()
    {
        switch (scene)
        {
            case SceneState.Title:
                break;
            case SceneState.Play:
                SceneManager.LoadScene("MainScene");
                currentscene = SceneManager.GetActiveScene();
                break;
            case SceneState.GoodEnd:
                break;
            case SceneState.BadEnd:
                break;
            case SceneState.Credits:
                break;
            case SceneState.GameRestart: 
                SceneManager.LoadScene(currentscene.name);
                break;
            default:
                break;

        }
    }

    public void StartGame()
    {
        scene = SceneState.Play;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
