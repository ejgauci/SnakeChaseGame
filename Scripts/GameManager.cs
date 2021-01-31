using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // public int ateNo=0;

    public Text usernameText;
    public string username = "";
    public bool alreadyname;


    public float time = 0f;

    GameObject timerUI;
    public GameObject timer;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void Scan()
    {
        GameObject.Find("AStarGrid").GetComponent<AstarPath>().Scan();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "startingScene")
        {

            usernameText = GameObject.Find("Text").GetComponent<Text>();
            username = usernameText.text;
        }

        if(timerUI == null)
        {
            if(!(SceneManager.GetActiveScene().name == "startingScene"))
            {
                timerUI = Instantiate(timer, new Vector3(0f, 0f, 0f), Quaternion.identity);

                //the default value for the timer is started
                timerUI.GetComponentInChildren<timerManager>().timerStarted = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {

            Camera.main.GetComponent<foodGenerator>().enabled = true;
            Camera.main.GetComponent<snakeGenerator>().enabled = true;
        }

        if(SceneManager.GetActiveScene().name == "winningScene" || SceneManager.GetActiveScene().name == "DeathScene")
        {
            timerUI.GetComponentInChildren<timerManager>().timerPaused = true;
        }
    }

    public void mainMenu()
    {
        username = "";
        time = 0;
        SceneManager.LoadScene("startingScene");
    }

}
