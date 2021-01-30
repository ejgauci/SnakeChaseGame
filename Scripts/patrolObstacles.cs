using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolObstacles : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    public int currentWayPoint;

    public List<Transform> waypoints;

    bool reverse = false;


    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        currentWayPoint = 0;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            if (this.transform.position != waypoints[currentWayPoint].position )
            {
                //print("obstacle moving");
                this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[currentWayPoint].position, 1f);
                gm.Scan();
                yield return new WaitForSeconds(1);

            }
            else if(reverse==true)
            {
                if(this.transform.position == waypoints[0].position)
                {
                    reverse = false;
                }
                else{
                    currentWayPoint--;
                }
                

            }
            else
            {
                currentWayPoint++;
            }

            if (currentWayPoint >= waypoints.Count)
            {
                currentWayPoint --;
                reverse = true;
                //yield return new WaitForSeconds(1);


            }
        }

     }

    
}