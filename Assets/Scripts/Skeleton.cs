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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
