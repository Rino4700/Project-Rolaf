using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMPro.TMP_Text ScoreText;

    void Start()
    {
        ScoreText = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        ScoreText.text = "Score: " + GameManager.instance.GetScore();
    }
}
