using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScreenController : MonoBehaviour
{
    int amountDown = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (amountDown)
            {
                case 0:
                    SceneManager.LoadScene("characterSelect");
                    break;
                case 1:
                    SceneManager.LoadScene("options");
                    break;
                case 2:
                    SceneManager.LoadScene("controls");
                    break;
                case 3:
                    Application.Quit();
                    break;
                        
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (amountDown == 3)
            {

            }
            else
            {
                amountDown++;
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
            }
        }
    }
}
