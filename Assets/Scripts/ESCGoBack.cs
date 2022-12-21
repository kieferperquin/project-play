using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCGoBack : MonoBehaviour
{
    string sceneName;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sceneName == "start")
            {
                Application.Quit();
            }
            if (sceneName == "options")
            {
                SceneManager.LoadScene("start");
            }
            if (sceneName == "controls")
            {
                SceneManager.LoadScene("start");
            }
            if (sceneName == "characterSelect")
            {
                SceneManager.LoadScene("start");
            }
            if (sceneName == "mapSelect")
            {
                SceneManager.LoadScene("characterSelect");
            }
        }
    }
}
