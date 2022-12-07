using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour // script for pause menu
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public int lifes;

    Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        playerPref player1 = new playerPref(3);

        player1.lifesP1 = lifes;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        anim.SetBool("pause", false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pause()
    {
        anim.SetBool("pause", true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}