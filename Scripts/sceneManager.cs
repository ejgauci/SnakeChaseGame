using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void Load(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }

    public void Restart()
    {
        //SceneManager.LoadScene(1);
        gm.restart();
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(0);
        gm.mainMenu();
    }

    public void deathScene()
    {
        SceneManager.LoadScene(4);
    }

 

    internal static object GetActiveScene()
    {
        throw new NotImplementedException();
    }
}