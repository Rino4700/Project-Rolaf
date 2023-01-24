using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float velocity = 1;
    public GameObject Player;
    SpriteRenderer rend;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, velocity * Time.deltaTime); //El zombi seguira al jugador directamente desde la posici�n X.
        Flip();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
