using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int Score = 0;
    private float time = 0;

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
        return time;
    }

}
