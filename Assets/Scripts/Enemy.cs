using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float velocity = 0;
    public GameObject Target;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(-velocity * Time.deltaTime, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement_Rolaf>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.GetComponent<Deathzone>())
        {
            Destroy(gameObject);
        }
    }
}
