using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    void Start()
    {

    }

    public void ChangeScene(string name)
    {
        GameManager.instance.time = 0;
        GameManager.instance.ChangeScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
