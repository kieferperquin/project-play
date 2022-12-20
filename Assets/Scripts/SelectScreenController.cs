using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScreenController : MonoBehaviour
{
    int amountDown = 0;
    public GameObject arrow;

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
                updateArrowPos();
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
                updateArrowPos();
            }
        }
        void updateArrowPos()
        {
            switch (amountDown)
            {
                case 0:
                    arrow.transform.position = new Vector2(transform.position.x, 1.3f);
                    break;

                case 1:
                    arrow.transform.position = new Vector2(transform.position.x, -0.45f);
                    break;

                case 2:
                    arrow.transform.position = new Vector2(transform.position.x, -2f);
                    break;

                case 3:
                    arrow.transform.position = new Vector2(transform.position.x, -3.45f);
                    break;

                default:
                    break;
            }
        }
    }
}
