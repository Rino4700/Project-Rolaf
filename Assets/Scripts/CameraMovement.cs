using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        float x = Player.transform.position.x;
        float y = Player.transform.position.y;
        if(Player.transform.position.y >= 6)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(x, 0, transform.position.z);
        }

    }
}
