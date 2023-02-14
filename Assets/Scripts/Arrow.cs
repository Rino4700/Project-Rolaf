using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public GameObject Player;
    public SpriteRenderer rend;
    public Rigidbody2D rb;
    public float speed = 20;
    public float maxTime = 2;
    float currentTime;
    public AudioClip PlayerDeathAudio;
    [Range(0, 1)]
    public float volumemusic;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Flip();
    }
    void Flip()
    {
        if (Player.transform.position.x > transform.position.x) //Cuando el jugador se encuentre en una posicion mayor a la del objeto, dicho objeto se girara horizontalmente.
        {
            rend.flipX = true;
            rb.velocity = new Vector2(10, 0);
        }
        else
        {
            rend.flipX = false;
            rb.velocity = new Vector2(-10, 0);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime; //Cuando la flecha alcance o supere el tiempo maximo, la flecha se destruirá.
        if (currentTime >= maxTime)
        {
            Destroy(gameObject);
            currentTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)  //Cuando el colider del objeto colisione con el del jugador la escena se resetea.
    {
        if (collision.GetComponent<Movement_Rolaf>())
        {
            GameManager.instance.Score = 0;
            GameManager.instance.ChangeScene(SceneManager.GetActiveScene().name);
            AudioManager.instance.PlayAudio(PlayerDeathAudio, volumemusic);
        }
    }
}
