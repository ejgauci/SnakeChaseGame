using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ateNo=0;
    public string username = "";
    public float time = 0f;


    public void ateFood()
    {
        ateNo++;
    }
}
