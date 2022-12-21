using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectorP2 : MonoBehaviour
{
    int select = 0;
    int selected;
    public GameObject arrow;
    public GameObject selector;
    public bool P2Selected = false;
    private static readonly string CharacterP2Pref = "CharacterP2Pref";

    void Start()
    {
        updateArrowPos();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            PlayerPrefs.SetInt(CharacterP2Pref, select);
            P2Selected = true;
            selected = select;
            SetSelected();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (select <= 2)
            {
                
            }
            else
            {
                select = select - 3;
                updateArrowPos();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (select == 0)
            {

            }
            else
            {
                select--;
                updateArrowPos();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (select >= 3)
            {

            }
            else
            {
                select = select + 3;
                updateArrowPos();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (select == 5)
            {

            }
            else
            {
                select++;
                updateArrowPos();
            }
        }
    }

    void updateArrowPos()
    {
        switch (select)
        {
            case 0:
                arrow.transform.position = new Vector2(-2.75f, 3.3f);
                break;

            case 1:
                arrow.transform.position = new Vector2(0.65f, 3.3f);
                break;

            case 2:
                arrow.transform.position = new Vector2(3.65f, 3.3f);
                break;

            case 3:
                arrow.transform.position = new Vector2(-2.75f, 0.1f);
                break;

            case 4:
                arrow.transform.position = new Vector2(0.65f, 0.1f);
                break;

            case 5:
                arrow.transform.position = new Vector2(3.65f, 0.1f);
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
                selector.transform.position = new Vector3(-2.75f, 3.3f, 2f);
                break;

            case 1:
                selector.transform.position = new Vector3(0.65f, 3.3f, 2f);
                break;

            case 2:
                selector.transform.position = new Vector3(3.65f, 3.3f, 2f);
                break;

            case 3:
                selector.transform.position = new Vector3(-2.75f, 0.1f, 2f);
                break;

            case 4:
                selector.transform.position = new Vector3(0.65f, 0.1f, 2f);
                break;

            case 5:
                selector.transform.position = new Vector3(3.65f, 0.1f, 2f);
                break;

            default:
                break;
        }
    }
}
