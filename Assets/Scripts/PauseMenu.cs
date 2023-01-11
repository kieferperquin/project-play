using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
    int amountDown = 0;
    int whoPaused = 0;
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject arrowP1;
    public GameObject arrowP2;

    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        resume();
    }

    void Update()
    {
        if (whoPaused == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    whoPaused = 0;
                    resume();
                }
                else
                {
                    whoPaused = 1;
                    pauseP1();
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (GameIsPaused)
                {
                    whoPaused = 0;
                    resume();
                }
                else
                {
                    whoPaused = 2;
                    pauseP2();
                }
            }
        }
        else if (whoPaused == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    whoPaused = 0;
                    resume();
                }
                else
                {
                    whoPaused = 1;
                    pauseP1();
                }
            }
        }
        else if (whoPaused == 2)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (GameIsPaused)
                {
                    whoPaused = 0;
                    resume();
                }
                else
                {
                    whoPaused = 2;
                    pauseP2();
                }
            }
        }

        if (whoPaused == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (amountDown)
                {
                    case 0:
                        resume();
                        break;

                    case 1:
                        SceneManager.LoadScene("start");
                        break;

                    case 2:
                        Application.Quit();
                        break;

                    default:
                        break;
                }
            }
        
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (amountDown == 2)
                {

                }
                else
                {
                    amountDown++;
                    updateArrowPosP1();
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (amountDown == 0)
                {

                }
                else
                {
                    amountDown--;
                    updateArrowPosP1();
                }
            }
        }
        if (whoPaused == 2)
        {
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                switch (amountDown)
                {
                    case 0:
                        resume();
                        break;

                    case 1:
                        SceneManager.LoadScene("start");
                        break;

                    case 2:
                        Application.Quit();
                        break;

                    default:
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (amountDown == 2)
                {

                }
                else
                {
                    amountDown++;
                    updateArrowPosP2();
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (amountDown == 0)
                {

                }
                else
                {
                    amountDown--;
                    updateArrowPosP2();
                }
            }
        }
    }
    public void resume()
    {
        anim.SetBool("pause", false);
        pauseMenuUI.SetActive(false);
        arrowP1.transform.position = new Vector2(100f, 100f);
        arrowP2.transform.position = new Vector2(100f, 100f);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pauseP1()
    {
        anim.SetBool("pause", true);
        pauseMenuUI.SetActive(true);
        updateArrowPosP1();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void pauseP2()
    {
        anim.SetBool("pause", true);
        pauseMenuUI.SetActive(true);
        updateArrowPosP2();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void updateArrowPosP1()
    {
        switch (amountDown)
        {
            case 0:
                arrowP1.transform.position = new Vector3(5f, 1.25f, -9.5f);
                break;

            case 1:
                arrowP1.transform.position = new Vector3(3.3f, -1f, -9.5f);
                break;

            case 2:
                arrowP1.transform.position = new Vector3(2.8f, -2.5f, -9.5f);
                break;

            default:
                break;
        }
    }
    void updateArrowPosP2()
    {
        switch (amountDown)
        {
            case 0:
                arrowP2.transform.position = new Vector3(5f, 1.25f, -9.5f);
                break;

            case 1:
                arrowP2.transform.position = new Vector3(3.3f, -1f, -9.5f);
                break;

            case 2:
                arrowP2.transform.position = new Vector3(2.8f, -2.5f, -9.5f);
                break;

            default:
                break;
        }
    }
}