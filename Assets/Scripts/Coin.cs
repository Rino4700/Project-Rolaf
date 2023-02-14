using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public AudioClip CoinSound;
    [Range(0, 1)]
    public float volumemusic;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //Si el objeto colisiona con el jugador, destruirá el objeto "padre".
    {
        if (collision.GetComponent<Movement_Rolaf>())
        {
            AudioManager.instance.PlayAudio(CoinSound,volumemusic);
            GameManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
