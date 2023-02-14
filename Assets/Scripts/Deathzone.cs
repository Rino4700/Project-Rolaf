using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    public AudioClip FallAudio;
    [Range(0, 1)]
    public float volumemusic;

    private void OnTriggerEnter2D(Collider2D collision) //Si el jugador colisiona con el objeto, la escena se resetea.
    {
        if (collision.GetComponent<Movement_Rolaf>())
        {
            AudioManager.instance.PlayAudio(FallAudio,volumemusic);
            GameManager.instance.Score = 0;
            GameManager.instance.ChangeScene(SceneManager.GetActiveScene().name);
        }
    }
}
