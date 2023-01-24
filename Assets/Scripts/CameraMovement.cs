using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float maxY = 6;
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        float x = Player.transform.position.x;
        float y = Player.transform.position.y;
        if(Player.transform.position.y >= maxY) //Si la camara supera una posicion Y, la camara se movera hacia arriba.
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(x, 0, transform.position.z);
        }

    }
}
