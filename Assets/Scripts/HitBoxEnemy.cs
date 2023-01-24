using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxEnemy : MonoBehaviour
{
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
            Destroy(transform.parent.gameObject);
        }
    }
}
