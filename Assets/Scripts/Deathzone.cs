using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    public AudioClip FallAudio;
    [Range(0, 1)]
    public float volumemusic;
    public bool InRange;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.GetComponent<Movement_Rolaf>())
        {
            if(InRange == false) //Cuando el jugador colisione con el booleano "InRange" en false, reproducira un sonido.
            {
                AudioManager.instance.PlayAudio(FallAudio, volumemusic);
            }
            if (InRange == true) //Cuando el jugador colisione con el booleano "InRange" en true, la escena se resetea.
            {
                GameManager.instance.Score = 0;
                GameManager.instance.ChangeScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
