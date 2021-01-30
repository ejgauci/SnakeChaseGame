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
            if (this.transform.position != waypoints[currentWayPoint].position)
            {
                print("obstacle moving");
                this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[currentWayPoint].position, 1f);
                gm.Scan();
                yield return new WaitForSeconds(0.5f);

            }
            else
            {
                currentWayPoint++;
            }

            if (currentWayPoint >= waypoints.Count)
            {
                currentWayPoint = 0;
                yield return new WaitForSeconds(1);

            }
        }

        
    }
}
