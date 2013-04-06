using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public float distanceBetween;
    private GameObject mainChar;
    private Vector3 enemyDirection;
    private RaycastHit raycastHit;
    private float colisionDistance = 5.0f;
    private Quaternion rotation;
    public float enemySpeed = 4.0f;
    public float enemySpeedHigh = 4.5f;
    public float enemySpeedNormal = 3.0f;
    public float enemySpeedSlow = 2.0f;
    public float distanceToFollow = 10.0f;
    public float distanceToFollowHighSpeed = 10.0f;
    public float distanceToFollowMediumSpeed = 20.0f;
    public float distanceToFollowSlowSpeed = 30.0f;

    public string stateEnemy;

    public float enemyTeleportDistanceX = 20f;
    public float enemyTeleportDistanceZ = 20f;

    public string panicTeleportState;

    public GameObject PickObject;
    PickObject mScript;

    public bool playerCanEscape;

    void Awake()
    {
        mainChar = GameObject.FindGameObjectWithTag("MainCharacter");
        mScript = PickObject.GetComponent<PickObject>();
    }


	// Use this for initialization
	void Start ()
	{
	    stateEnemy = "Steady";
	    playerCanEscape = false;


	}
	
	// Update is called once per frame
	void Update ()
	{
	    distanceBetween = Vector3.Distance(mainChar.transform.position, gameObject.transform.position);

        if(mScript.objectPicked == true)
        {
            if (mScript.objectPickedCount == 0)
            {
                stateEnemy = "Steady";
                mScript.objectPicked = false;

            }
            else if (mScript.objectPickedCount == 1)
            {
                stateEnemy = "PanicTeleport";
                panicTeleportState = "Two";
                mScript.objectPicked = false;

            }
            else if (mScript.objectPickedCount == 2)
            {
                stateEnemy = "PanicTeleport";
                panicTeleportState = "Three";
                enemySpeed = 2;//enemyspeedslow
                mScript.objectPicked = false;
            }
            else if (mScript.objectPickedCount == 3)
            {
                enemySpeed = 2;     //enemyspeedslow
                mScript.objectPicked = false;
            }
            else if (mScript.objectPickedCount == 4)
            {
                enemySpeed = 3; //enemyspeedmedium
                mScript.objectPicked = false;
            }
            else if (mScript.objectPickedCount == 5)
            {
                enemySpeed = 4;     //enemyspeedhigh
                mScript.objectPicked = false;
            }            
        }
       



        switch(stateEnemy)
        {
            case "Moving":
                MoveEnemy();
                break;

            case "Teleport":
                TeleportEnemy();
                break;

            case "Steady":
                break;

            case "PanicTeleport":
                PanicTeleportSelector();
                break;
            case "TeleportOutside":
                TeleportOutside();
                break;
        }


	}


    void MoveEnemy()
    {
        
        if (distanceBetween < distanceToFollow)
        {

            if (distanceBetween < 3)
            {
 
                    stateEnemy = "Teleport";
                    //Debug.Log("teleport!!!");

            }

        }
        else
        {
            stateEnemy = "Teleport";          //TeleportEnemy();
            //Debug.Log("teleport enemy!!!");
        }

        enemyDirection = (mainChar.transform.position - gameObject.transform.position).normalized;
        //Debug.Log("enemy direction: " + enemyDirection);
            
        //Debug.Log(" obstacle ray hit " + hit.collider.gameObject.name);

        rotation = Quaternion.LookRotation(enemyDirection);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, Time.deltaTime);
        gameObject.transform.position += gameObject.transform.forward * enemySpeed * Time.deltaTime;


    }

    void TeleportEnemy()
    {
        RandomTeleportDistance();
        this.gameObject.transform.position = mainChar.transform.position + new Vector3(enemyTeleportDistanceX,0,enemyTeleportDistanceZ);     //basic teleport
        stateEnemy = "Moving";
        //Debug.Log("beni cagirdilar");

    }

    void TeleportOutside()
    {
        this.gameObject.transform.position = mainChar.transform.position + new Vector3(75, 0, 75);     //basic teleport
        stateEnemy = "Steady";

    }

    void RandomTeleportDistance()
    {
        enemyTeleportDistanceX = Random.Range(-50, 50);     //maybe, should be avoided from near distances
        enemyTeleportDistanceZ = Random.Range(-50, 50);     //maybe, should be avoided from near distances
        //Debug.Log("enemyTeleportDistanceX" + enemyTeleportDistanceX);
        //Debug.Log("enemyTeleportDistanceZ" + enemyTeleportDistanceZ);
    }

    void PanicTeleportSelector()
    {
        switch (panicTeleportState)
        {
            case "One":
                PanicTeleportOne();
                break;

            case "Two":
                PanicTeleportTwo();
                break;

            case "Three":
                PanicTeleportThree();
                break;

            case "Steady":
                break;
            case "WatchMe":
                WatchMe();
                break;
            case "StareMe":
                StareMe();
                break;

        }

    }

    void PanicTeleportOne()
    {


        if(distanceBetween < 25)
        {
            //Debug.Log("panicteleport time!!!!!!!!!");
            //gameObject.transform.position += gameObject.transform.forward * 15 * Time.deltaTime;

            Vector3 difference = gameObject.transform.position - mainChar.transform.position;
            gameObject.transform.position -= difference.normalized * 10 *Time.deltaTime;
            if(distanceBetween < 3)
            {
                gameObject.active = false;
            }

        }
        else
        {
            distanceBetween = Vector3.Distance(mainChar.transform.position, gameObject.transform.position);
            //Debug.Log("distance" + distanceBetween);
            enemyDirection = (mainChar.transform.position - gameObject.transform.position).normalized;
            rotation = Quaternion.LookRotation(enemyDirection);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rotation, Time.deltaTime);
            gameObject.transform.position += gameObject.transform.forward * 15 * Time.deltaTime;
        }
    }

    void PanicTeleportTwo()
    {
        //teleport next to the character and stare
        this.gameObject.transform.position = mainChar.transform.position + new Vector3(2, 0, 2);
        panicTeleportState = "WatchMe";
        //stateEnemy = "Steady";
        //Debug.Log("oalala");

    }

    void PanicTeleportThree()
    {
        //teleport next to the character and stare
        this.gameObject.transform.position = mainChar.transform.position + new Vector3(-2, 0, 0);
        panicTeleportState = "StareMe";
        //stateEnemy = "Steady";
    }

    void Steady()
    {
        //Debug.Log("yes i'm waiting...");
    }

    void WatchMe()
    {
        //Debug.Log("hehehe im watching");
        //gameObject.transform.rotation = mainChar.transform.rotation;

        if (distanceBetween > 10)
        {
            //Debug.Log("watch meden cikar");
            //Change the state
            panicTeleportState = "Steady";
            stateEnemy = "TeleportOutside";
            //stateEnemy = "Steady";

        }

    }


    void StareMe()
    {
        //Debug.Log("hehehe im watching");
        gameObject.transform.rotation = mainChar.transform.rotation;


        if (distanceBetween > 10)
        {
            //Debug.Log("watch meden cikar");
            //Change the state
            panicTeleportState = "Steady";
            stateEnemy = "Teleport";
            //stateEnemy = "Steady";

        }
    }



}
