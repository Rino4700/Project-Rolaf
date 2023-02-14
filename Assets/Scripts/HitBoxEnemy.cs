using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxEnemy : MonoBehaviour
{
    public AudioClip ZombieDeath;
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
            GameManager.instance.AddScore(20);
            Destroy(transform.parent.gameObject);
            AudioManager.instance.PlayAudio(ZombieDeath,volumemusic);
        }
    }
}
