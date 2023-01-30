using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(string name)
    {
        GameManager.instance.AddScore(20);
        Debug.LogError(GameManager.instance.GetScore());
    }
}
