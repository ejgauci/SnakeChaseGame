using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;
using UnityEngine.SceneManagement;

public class customAIMoveScriptGrid : MonoBehaviour
{
    //the object that we are using to generate the path
    Seeker seeker;

    //path to follow stores the path
    Path pathToFollow;

    //a reference from the UI to the green box
    public Transform target;

    //a reference to PointGraphObject
    GameObject graphParent;
    int enemyAI;

    foodGenerator myfoodgenerator;


    //the node of the graph that is going to correspond with the green box
    //GameObject targetNode;

    public List<Transform> obstacleNodes;

    SpawnEnemyAI spawnEnemyAI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("ai hit moving obstacle");


        }
        else
        {
            Debug.Log("ai collided with player");

            SceneManager.LoadScene(4);
        }
        


    }
    /*
    private void Update()
    {
        if ((transform.position.x < -(Camera.main.orthographicSize - 1)) || (transform.position.x > (Camera.main.orthographicSize - 1)))
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y);
        }

        if ((transform.position.y < -(Camera.main.orthographicSize - 1)) || (transform.position.y > (Camera.main.orthographicSize - 1)))
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y);
        }

        myfoodgenerator.eatFood(this.transform.position);
    }*/



    // Start is called before the first frame update
    void Start()
    {
        // enemyTail = Camera.main.GetComponent<SpawnEnemyAI>().snakelength;

        spawnEnemyAI = GetComponent<SpawnEnemyAI>();
        target = GameObject.Find("blackPlayerBox").transform;


        //Debug.Log(this.name);

        //the instance of the seeker attached to this game object
        seeker = GetComponent<Seeker>();


        //node target by name
        //targetNode = GameObject.Find("TargetNode");

        //find the parent node of the point graph
         //graphParent = GameObject.Find("PointGraphObject");
        graphParent = GameObject.Find("AStarGrid");
        //we scan the graph to generate it in memory
        graphParent.GetComponent<AstarPath>().Scan();

        //generate the initial path
        pathToFollow = seeker.StartPath(transform.position, target.position);



        //update the graph as soon as you can.  Runs indefinitely
        StartCoroutine(updateGraph());

        //move the red robot towards the green enemy
        StartCoroutine(moveTowardsEnemy(this.transform));
    }

   


    IEnumerator updateGraph()
    {
        while (true)
        {

      //   targetNode.transform.position = target.position;
            graphParent.GetComponent<AstarPath>().Scan();


            yield return null;

        }

    }

  
    IEnumerator moveTowardsEnemy(Transform t)
    {
        

        while (true)
        {

            List<Vector3> posns = pathToFollow.vectorPath;
            //Debug.Log("Positions Count: " + posns.Count);

            for (int counter = 0; counter < posns.Count; counter++)
            {
                // Debug.Log("Distance: " + Vector3.Distance(t.position, posns[counter]));
                if (posns[counter] != null) { 
                    while (Vector3.Distance(t.position, posns[counter]) >= 0.5f)
                    {
                        t.position = Vector3.MoveTowards(t.position, posns[counter], 1f);
                        //since the enemy is moving, I need to make sure that I am following him
                        pathToFollow = seeker.StartPath(t.position, target.position);
                        //wait until the path is generated
                        yield return seeker.IsDone();
                        //if the path is different, update the path that I need to follow
                        posns = pathToFollow.vectorPath;



                        Camera.main.GetComponent<SpawnEnemyAI>().savePosition();
                        Camera.main.GetComponent<SpawnEnemyAI>().enemyDrawTail(Camera.main.GetComponent<SpawnEnemyAI>().snakelength);

                      //  Debug.Log("@:" + t.position + " " + target.position + " " + posns[counter]);
                        yield return new WaitForSeconds(0.2f);
                    }

                }
                //keep looking for a path because if we have arrived the enemy will anyway move away
                //This code allows us to keep chasing
                pathToFollow = seeker.StartPath(t.position, target.position);
                yield return seeker.IsDone();
                posns = pathToFollow.vectorPath;
                //yield return null;

            }
            yield return null;
        }
    }




}


