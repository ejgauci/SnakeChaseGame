using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winningScore : MonoBehaviour
{
    public string namePlayer;
    public string timePlayer;

    GameManager gm;

    public GameObject nameText;
    public GameObject timeText;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        namePlayer = gm.username;

        float minutes = Mathf.FloorToInt(gm.time / 60f);
        float seconds = Mathf.FloorToInt(gm.time % 60f);
        timePlayer = string.Format("{0:00}:{1:00}", minutes, seconds);


        nameText.GetComponent<Text>().text = "Username: " + namePlayer;
        timeText.GetComponent<Text>().text = "Time: " + timePlayer;


    }

}
