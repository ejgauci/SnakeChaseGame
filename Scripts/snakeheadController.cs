using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snakeheadController : MonoBehaviour
{
    snakeGenerator mysnakegenerator;
    foodGenerator myfoodgenerator;
    public GameObject portal;
    Color portalColor;



    public Vector3 findClosestFood()
    {
        if (myfoodgenerator.allTheFood.Count > 0)
        {
            List<positionRecord> sortedFoods = myfoodgenerator.allTheFood.OrderBy(
        x => Vector3.Distance(this.transform.position, x.Position)
       ).ToList();
            return sortedFoods[0].Position;
        }
        return new Vector3(0f, 0f);
    }

    public IEnumerator automoveCoroutine()
    {
        while(true)
        {


            yield return null;
        }
        
    }



    private void Start()
    {
        mysnakegenerator = Camera.main.GetComponent<snakeGenerator>();
        myfoodgenerator = Camera.main.GetComponent<foodGenerator>();

        portal = GameObject.Find("Portal");
        

    }

    //sceneManager sm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "movingObstacle")
        {
            Debug.Log("Wall");
            //sm.deathScene();
            SceneManager.LoadScene(4);


        }
        if (collision.gameObject.tag == "Portal")
        {
            Debug.Log("Portal");

            

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                if (mysnakegenerator.getLength() >= 8)
                {
                    SceneManager.LoadScene(2);
                }

            }else
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                if (mysnakegenerator.getLength() >= 8)
                {
                    SceneManager.LoadScene(3);
                }

            }
            else
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                if (mysnakegenerator.getLength() >= 8)
                {
                    SceneManager.LoadScene(5);
                }

            }



        }
        else 
        {
            Debug.Log("MyOtherTag");
        }
        
    }


    void checkBounds()
    {
        if ((transform.position.x < -(Camera.main.orthographicSize-1)) || (transform.position.x > (Camera.main.orthographicSize - 1)))
        {
            transform.position = new Vector3(-transform.position.x,transform.position.y);
        }

        if ((transform.position.y < -(Camera.main.orthographicSize - 1)) || (transform.position.y > (Camera.main.orthographicSize - 1)))
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y);
        }


    }
    


    // Update is called once per frame
    void Update()
    {
       


        if (mysnakegenerator.getLength() >= 8)
        {
            portal.GetComponent<SpriteRenderer>().color = Color.green;
        }



        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //Debug.LogWarning("Closest food" + findClosestFood());
            transform.position -= new Vector3(1f,0);
            checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
           // mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.LogWarning("Closest food" + findClosestFood());
            transform.position += new Vector3(1f, 0);
            checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
           // mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.LogWarning("Closest food" + findClosestFood());
            transform.position += new Vector3(0, 1f);
            checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
            //mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.LogWarning("Closest food" + findClosestFood());
            transform.position -= new Vector3(0, 1f);
            checkBounds();
            myfoodgenerator.eatFood(this.transform.position);
            //mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength);
        }
        
        

        mysnakegenerator.hitTail(this.transform.position, mysnakegenerator.snakelength); 
    }
}
