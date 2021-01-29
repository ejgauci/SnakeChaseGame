using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void deathScene()
    {
        SceneManager.LoadScene(3);
    }


}
