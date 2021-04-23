using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private GameObject losePanel = null;

    private float maxTime = 121;
    private TextMeshProUGUI timerText;
    private int minutes, seconds;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        if (maxTime>0)
        {
            maxTime = maxTime - Time.deltaTime;
        }
        if(maxTime < 10)
        {
            timerText.color = Color.red;
        }
        if( maxTime <=0)
        {
            losePanel.SetActive(true);
        }
       
        minutes = (int)(maxTime / 60);
        seconds = (int)(maxTime % 60);
    }
    void Update()
    {
        timerText.text = "TIME LEFT " + minutes + ":" + seconds.ToString("00");
    }
}
