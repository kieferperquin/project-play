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
            if (sceneName == "options")
            {
                GameObject.Find("ChangeVolume").GetComponent<AudioManager>().SaveSoundSettings();
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
