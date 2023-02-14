using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    public float maxTime = 2;
    public float currentTime = 0;
    public AudioClip FallAudio;
    [Range(0, 1)]
    public float volumemusic;

    private void OnTriggerEnter2D(Collider2D collision) //Si el jugador colisiona con el objeto, la escena se resetea.
    {
        if (collision.GetComponent<Movement_Rolaf>())
        {
            currentTime += Time.deltaTime;
            AudioManager.instance.PlayAudio(FallAudio);
            if (currentTime >= maxTime)
            {
                GameManager.instance.Score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
