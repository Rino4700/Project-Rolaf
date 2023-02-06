using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    public TMPro.TMP_Text timeText;

    void Start()
    {
        timeText = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        timeText.text = "Time: " + GameManager.instance.GetTime();
    }
}
