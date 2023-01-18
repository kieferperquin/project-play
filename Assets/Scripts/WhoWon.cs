using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhoWon : MonoBehaviour
{
    private static readonly string p1Won = "p1Won";
    private static readonly string p2Won = "p2Won";

    int p1DidWin;
    int p2DidWin;

    private int p1ArrowDown;
    private int p2ArrowDown;

    public GameObject p1WinScreen;
    public GameObject p2WinScreen;

    public GameObject arrowP1;
    public GameObject arrowP2;

    private void Start()
    {
        p1DidWin = PlayerPrefs.GetInt(p1Won);
        p2DidWin = PlayerPrefs.GetInt(p2Won);

        if (p1DidWin == 1 && p2DidWin == 0)
        {
             p1WinScreen.transform.position = new Vector3(0, 0, 0);
        }
        else if (p1DidWin == 0 && p2DidWin == 1)
        {
            p2WinScreen.transform.position = new Vector3(0, 0, 0);
        }
        else
        {

        }
    }
    private void Update()
    {
        if (p1DidWin == 1 && p2DidWin == 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (p1ArrowDown)
                {
                    case 0:
                        SceneManager.LoadScene("start");
                        break;

                    case 1:
                        Application.Quit();
                        break;

                    default:
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                p1ArrowDown++;
                updateArrowPosP1();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                p1ArrowDown--;
                updateArrowPosP1();
            }
        }
        if (p1DidWin == 0 && p2DidWin == 1)
        {
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                switch (p2ArrowDown)
                {
                    case 0:
                        SceneManager.LoadScene("start");
                        break;

                    case 1:
                        Application.Quit();
                        break;

                    default:
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                p2ArrowDown++;
                updateArrowPosP2();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                p2ArrowDown--;
                updateArrowPosP2();
            }
        }
    }
    void updateArrowPosP1()
    {
        switch (p1ArrowDown)
        {
            case 0:
                arrowP1.transform.position = new Vector2(3.5f, 0f);
                break;

            case 1:
                arrowP1.transform.position = new Vector2(3.5f, -3f);
                break;

            default:
                break;
        }
    }
    void updateArrowPosP2()
    {
        switch (p2ArrowDown)
        {
            case 0:
                arrowP2.transform.position = new Vector2(3.5f, 0f);
                break;

            case 1:
                arrowP2.transform.position = new Vector2(3.5f, -3f);
                break;

            default:
                break;
        }
    }
}
