using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private static readonly string p1Won = "p1Won";
    private static readonly string p2Won = "p2Won";

    private void Start()
    {
        PlayerPrefs.SetInt(p1Won, 0);
    }
    public void P1HasWon()
    {
        PlayerPrefs.SetInt(p1Won, 1);
        SceneManager.LoadScene("winScreen");
    }
    public void P2HasWon()
    {
        PlayerPrefs.SetInt(p2Won, 2);
        SceneManager.LoadScene("winScreen");
    }
}
