using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score = 0;
    public float time = 0;

    void Awake()
    {
        if(!instance ) // instance != null
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // si tiene info, significa que ya hay otro GameManager
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
    }

    public void AddScore(int Value)
    {
        Score += Value;
    }
    
    public int GetScore()
    {
        return Score;
    }

    public float GetTime() 
    {
        return Mathf.Round(time);
    }

    public void ChangeScene(string name) 
    {
        SceneManager.LoadScene(name);
        AudioManager.instance.ClearAudioList();
    }
}
