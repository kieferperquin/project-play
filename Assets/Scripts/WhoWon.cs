using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoWon : MonoBehaviour
{
    private static readonly string p1Won = "p1Won";
    private static readonly string p2Won = "p2Won";

    int p1DidWin;
    int p2DidWin;

    public GameObject p1WinScreen;
    public GameObject p2WinScreen;

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
}
