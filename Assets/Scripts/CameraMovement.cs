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
        transform.Translate(new Vector3(Player.transform.position.x, 0, 0));
    }
}
