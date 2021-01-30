﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timerManager : MonoBehaviour
{

    public bool timerStarted;
    public bool timerPaused;

    float timerValue=0f;

    Text timerText;
    

    IEnumerator timer()
    {
        while(true)
        { 
            if (timerStarted)
            {
                //measure the time
                timerValue++;

                float minutes = Mathf.FloorToInt(timerValue / 60f);
                float seconds = Mathf.FloorToInt(timerValue % 60f);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


                //code that is running every second
                yield return new WaitForSeconds(1f);
            }
            else
            {
                //don't measure the time
                timerValue = 0f;
                timerText.text = string.Format("{0:00}:{1:00}", 0f, 0f);
                yield return null;

            }

            if (timerPaused)
            {
                float minutes = Mathf.FloorToInt(timerValue / 60f);
                float seconds = Mathf.FloorToInt(timerValue % 60f);

                timerText.color =Color.red;
                if(SceneManager.GetActiveScene().name == "DeathScene")
                {
                    timerText.color = Color.green;
                }

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        //the text component attached to THIS object
        timerText = GetComponent<Text>();
        StartCoroutine(timer()); 
    }

    
}
