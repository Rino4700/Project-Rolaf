using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skeleton : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer rend;
    public GameObject ArrowPrefab;
    public float maxTime = 20;
    public float currentTime;
    public AudioClip PlayerDeathAudio;
    public AudioClip BowShoot;
    [Range(0, 1)]
    public float volumemusic;
    public bool InRange;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Shoots();
        Flip();
    }
    private void Shoots()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime) //Cuando el contador llegue a un numero maximo de tiempo, el objeto creara un PreFab de la flecha.
        {
            currentTime = 0;
            GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
            if (InRange == true)
            {
                AudioManager.instance.PlayAudio(BowShoot,volumemusic);
            }
        }
    }
    private void Flip()
    {
        if (Player.transform.position.x > transform.position.x) //Cuando el jugador se encuentre en una posicion mayor a la del objeto, dicho objeto se girara horizontalmente.
        {
            rend.flipX = true;
        }
        else
        {
            rend.flipX = false;
        }
    }
        void OnCollisionEnter2D(Collision2D collision) //Cuando el colider del objeto colisione con el del jugador la escena se resetea.
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Score = 0;
            GameManager.instance.ChangeScene(SceneManager.GetActiveScene().name);
            AudioManager.instance.PlayAudio(PlayerDeathAudio,volumemusic);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Audio")
        {
            InRange = true;
        }
    }
}
