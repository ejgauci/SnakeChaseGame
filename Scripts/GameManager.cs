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
    public bool timerPaused = false;

    public float time = 0f;

    GameObject timerUI;
    public GameObject timer;

    void Awake()
    {
        setUpSingleton();
    }

    public void setUpSingleton()
    {
        int numberOfGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numberOfGameManagers > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Scan()
    {
        GameObject.Find("AStarGrid").GetComponent<AstarPath>().Scan();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("Skip level cheat");
            skipLevel();
        }

        if (SceneManager.GetActiveScene().name == "startingScene")
        {

            usernameText = GameObject.Find("Text").GetComponent<Text>();
            username = usernameText.text;
        }

        
       if(!(SceneManager.GetActiveScene().name == "startingScene"))
       {
          if (timerUI == null)
            {
                timerUI = Instantiate(timer, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
                //the default value for the timer is started
                timerUI.GetComponentInChildren<timerManager>().timerStarted = true;
       }
        

        if (SceneManager.GetActiveScene().name == "Level1")
        {

            Camera.main.GetComponent<foodGenerator>().enabled = true;
            Camera.main.GetComponent<snakeGenerator>().enabled = true;
        }

        if(SceneManager.GetActiveScene().name == "winningScene" || SceneManager.GetActiveScene().name == "DeathScene")
        {
            timerPaused = true;
            timerUI.GetComponentInChildren<timerManager>().timerPaused = true;
        }
    }

    public void mainMenu()
    {
        username = "";
        time = 0;
        SceneManager.LoadScene("startingScene");
    }

    public void restart()
    {
       
        time = 0;
        SceneManager.LoadScene("Level1");
    }

    public void skipLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene(2);
        }
        else
            if (SceneManager.GetActiveScene().name == "Level2")
        {

            SceneManager.LoadScene(3);
        }
        else
            if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene(5);

        }
    }


}
