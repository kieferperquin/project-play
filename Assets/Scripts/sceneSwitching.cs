using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitching : MonoBehaviour
{
    public void fight()
    {
        SceneManager.LoadScene("characterSelect");
    }
    public void home()
    {
        SceneManager.LoadScene("start");
    }
    public void options()
    {
        SceneManager.LoadScene("options");
    }
    public void controls()
    {
        SceneManager.LoadScene("controls");
    }
    public void mapselect()
    {
        SceneManager.LoadScene("mapSelect");
    }
    public void map1()
    {
        SceneManager.LoadScene("map1");
    }
    public void testScene()
    {
        SceneManager.LoadScene("mapTest");
    }
    public void quit()
    {
        Application.Quit();
    }
}
