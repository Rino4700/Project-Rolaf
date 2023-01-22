using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skeleton : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer rend;
    private Rigidbody2D rb;
    public GameObject ArrowPrefab;
    public float maxTime = 20;
    public float currentTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (currentTime >= maxTime)
        {
            currentTime = 0;
            GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
        }
    }
    private void Flip()
    {
        if (Player.transform.position.x > transform.position.x)
        {
            rend.flipX = true;
        }
        else
        {
            rend.flipX = false;
        }
    }
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
