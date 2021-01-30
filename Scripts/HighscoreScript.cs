using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerHighScores
{
    public string n;
    public float t;
}
public class HighscoreScript : MonoBehaviour
{/*

    public string[] names;
    public float[] times;

    GameManager gm;
    playerHighScores pHS;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        names = PlayerPrefsX.GetStringArray("Names", "", 1);
        times = PlayerPrefsX.GetFloatArray("Times", 0f, 1);

        if(names[0] == "")
        {
            names[0] = gm.username;
            times[0] = gm.time;

            PlayerPrefsX.SetStringArray("Names", names);
            PlayerPrefsX.SetFloatArray("Times", times);
        }
        else{
            pHS = new playerHighScores();
            List<playerHighScores> playerHSList = new List<playerHighScores>();

            for(int i = 0; i < names.Length; i++){
                pHS = new playerHighScores();
                pHS.n = names[i];
                pHS.t = times[i];
                playerHSList.Add(pHS);
            }
        }
    */
        }

}
