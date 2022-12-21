using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectorP2 : MonoBehaviour
{
    int select = 0;
    public GameObject arrow;
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
            P2Selected = true;
            PlayerPrefs.SetInt(CharacterP2Pref, select);
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
    public bool selected()
    {
        return P2Selected;
    }
}
