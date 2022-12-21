using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectorP1 : MonoBehaviour
{
    int select = 0;
    public GameObject arrow;
    bool P1Selected = false;
    private static readonly string CharacterP1Pref = "CharacterP1Pref";

    
    void Start()
    {
        updateArrowPos();
    }
    void Update()
    {
        if (P1Selected && GameObject.Find("characterSelector").GetComponent<CharacterSelectorP2>().P2Selected)
        {
            SceneManager.LoadScene("mapSelect");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetInt(CharacterP1Pref, select);
            P1Selected = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
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
        if (Input.GetKeyDown(KeyCode.A))
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
        if (Input.GetKeyDown(KeyCode.S))
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
        if (Input.GetKeyDown(KeyCode.D))
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
                arrow.transform.position = new Vector2(-2.2f, 3.3f);
                break;

            case 1:
                arrow.transform.position = new Vector2(1.2f, 3.3f);
                break;

            case 2:
                arrow.transform.position = new Vector2(4.2f, 3.3f);
                break;

            case 3:
                arrow.transform.position = new Vector2(-2.2f, 0.1f);
                break;

            case 4:
                arrow.transform.position = new Vector2(1.2f, 0.1f);
                break;

            case 5:
                arrow.transform.position = new Vector2(4.2f, 0.1f);
                break;

            default:
                break;
        }
    }
}
