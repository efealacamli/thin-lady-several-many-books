using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomObjectLocator : MonoBehaviour
{

    public Vector3 location1;
    public Vector3 location2;
    public Vector3 location3;
    public Vector3 location4;
    public Vector3 location5;
    public Vector3 location6;
    public Vector3 location7;
    public Vector3 location8;
    public Vector3 location9;
    public Vector3 location10;

    public GameObject[] pickableObjects;

    List <Vector3> locationsOdd;
    List <Vector3> locationsEven; 

    private int randomNumber;


	// Use this for initialization
	void Start () {

        location1 = new Vector3(38.58961f, 1.62341f, 5.389997f);
        location2 = new Vector3(38.56581f, 0.8143603f, 11.2767f);     //location 1 and 2 are for object1

        location3 = new Vector3(31.34132f, 2.159414f, 7.613633f);
        location4 = new Vector3(31.30934f, 0.5379665f, 15.2118f);     //location 3 and 4 are for object2

        location5 = new Vector3(15.15276f, 1.278045f, 12.91027f);
        location6 = new Vector3(11.98f, 0.810789f, 15.07923f);    //location 5 and 6 are for object3

        location7 = new Vector3(18.10713f, 1.628956f, 15.07093f);
        location8 = new Vector3(24.67094f, 1.365857f, 11.38838f); //location 7 and 8 are for object4

        location9 = new Vector3(38.36177f, 1.1906f, 27.08558f);
        location10 = new Vector3(24.27443f, 1.536721f, 28.42365f);   //location 9 and 10 are for object 5

	    pickableObjects = GameObject.FindGameObjectsWithTag("PickableObject");

	    locationsOdd = new List<Vector3>();
	    locationsEven = new List<Vector3>();

	    PutLocationsToArray();
	    RandomLocate();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PutLocationsToArray()
    {
        locationsOdd.Add(location1);
        locationsOdd.Add(location3);
        locationsOdd.Add(location5);
        locationsOdd.Add(location7);
        locationsOdd.Add(location9);
        
        locationsEven.Add(location2);
        locationsEven.Add(location4);
        locationsEven.Add(location6);
        locationsEven.Add(location8);
        locationsEven.Add(location10);
    
    }

    void RandomLocate()
    {
        
        //Debug.Log("length of array" + pickableObjects.Length.ToString());

        for (int i = 0; i < pickableObjects.Length; i++ )
        {
            //for each pickable objects assign a location and do the stuff that below
            //Debug.Log(pickableObjects[i].name + "pickableObjects");
            randomNumber = Random.Range(0, 10);

            if (randomNumber % 2 == 0)
            {
                //Debug.Log("even");
                pickableObjects[i].transform.position = locationsOdd[i];
            }
            else
            {
                //Debug.Log("odd");
                pickableObjects[i].transform.position = locationsEven[i];
            }
        }
    }
    
}
