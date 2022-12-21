using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    int select = 0;
    int selected;
    public GameObject arrow;
    public GameObject selector;

    private void Start()
    {
        UpdateArrowPos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (select >= 6)
            {
                switch (selected    )
                {
                    case 0:
                        map1();
                        break;

                    case 1:
                        map2();
                        break;

                    case 2:
                        map3();
                        break;

                    case 3:
                        map4();
                        break;

                    case 4:
                        map5();
                        break;

                    case 5:
                        map6();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                selected = select;
                SetSelected();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (select <= 2)
            {

            }
            else
            {
                select = select - 3;
                UpdateArrowPos();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (select == 0)
            {

            }
            else if (select >= 6)
            {
                select = 5;
                UpdateArrowPos();
            }
            else
            {
                select--;
                UpdateArrowPos();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (select >= 6)
            {
            }
            else
            {
                select = select + 3;
                UpdateArrowPos();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (select == 6)
            {

            }
            else
            {
                select++;
                UpdateArrowPos();
            }
        }
    }
    void UpdateArrowPos()
    {
        switch (select)
        {
            case 0:
                arrow.transform.position = new Vector2(-3.6f, 4.5f);
                break;

            case 1:
                arrow.transform.position = new Vector2(2.9f, 4.5f);
                break;

            case 2:
                arrow.transform.position = new Vector2(8.6f, 4.5f);
                break;

            case 3:
                arrow.transform.position = new Vector2(-3.6f, 0.8f);
                break;

            case 4:
                arrow.transform.position = new Vector2(2.9f, 0.8f);
                break;

            case 5:
                arrow.transform.position = new Vector2(8.6f, 0.8f);
                break;

            case 6:
                arrow.transform.position = new Vector2(8.5f, -4f);
                break;

            case 7:
                arrow.transform.position = new Vector2(8.5f, -4f);
                break;

            case 8:
                arrow.transform.position = new Vector2(8.5f, -4f);
                break;

            default:
                break;
        }
    }

    void SetSelected()
    {
        switch (selected)
        {
            case 0:
                selector.transform.position = new Vector3(-3.6f, 4.7f, 2f);
                break;

            case 1:
                selector.transform.position = new Vector3(2.9f, 4.7f, 2f);
                break;

            case 2:
                selector.transform.position = new Vector3(8.6f, 4.7f, 2f);
                break;

            case 3:
                selector.transform.position = new Vector3(-3.6f, 0.8f, 2f);
                break;

            case 4:
                selector.transform.position = new Vector3(2.9f, 0.8f, 2f);
                break;

            case 5:
                selector.transform.position = new Vector3(8.6f, 0.8f, 2f);
                break;

            default:
                break;
        }
    }

    public void map1()
    {
        SceneManager.LoadScene("map1");
    }
    public void map2()
    {
        SceneManager.LoadScene("map2");
    }
    public void map3()
    {
        SceneManager.LoadScene("map3");
    }
    public void map4()
    {
        SceneManager.LoadScene("map4");
    }
    public void map5()
    {
        SceneManager.LoadScene("map5");
    }
    public void map6()
    {
        SceneManager.LoadScene("map6");
    }
}
