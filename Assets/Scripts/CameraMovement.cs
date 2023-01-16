using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    private float x;
    void Start()
    {
        
    }

    void Update()
    {
        float x = Player.transform.position.x;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
