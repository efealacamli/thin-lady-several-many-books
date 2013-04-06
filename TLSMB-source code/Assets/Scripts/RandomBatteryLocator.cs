using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomBatteryLocator : MonoBehaviour
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

    public GameObject[] batteries;

    List<Vector3> locationsBatteryOdd;
    List<Vector3> locationsBatteryEven;

    private int randomNumber;


    // Use this for initialization
    void Start()
    {

        location1 = new Vector3(13.53801f, 0.3216844f, 10.64565f);
        location2 = new Vector3(17.77625f, 0.3216844f, 9.53439f);     //location 1 and 2 are for object1

        location3 = new Vector3(10.87639f, 1.179545f, 26.21978f);
        location4 = new Vector3(11.83352f, 1.520504f, 28.38186f); //location 3 and 4 are for object2

        location5 = new Vector3(31.36374f, 1.26616f, 9.140108f);
        location6 = new Vector3(25.06846f, 1.015212f, 8.272721f);    //location 5 and 6 are for object3

        location7 = new Vector3(23.20381f, 0.3216844f, 22.56446f);
        location8 = new Vector3(36.76319f, 0.3216844f, 19.77822f);     //location 7 and 8 are for object4

        location9 = new Vector3(64.39057f, 0.2305122f, 20.89226f);
        location10 = new Vector3(61.66459f, 0.2305122f, 22.36045f);   //location 9 and 10 are for object 5

        batteries = GameObject.FindGameObjectsWithTag("Battery");

        locationsBatteryOdd = new List<Vector3>();
        locationsBatteryEven = new List<Vector3>();

        PutLocationsToArray();
        RandomLocate();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PutLocationsToArray()
    {
        locationsBatteryOdd.Add(location1);
        locationsBatteryOdd.Add(location3);
        locationsBatteryOdd.Add(location5);
        locationsBatteryOdd.Add(location7);
        locationsBatteryOdd.Add(location9);

        locationsBatteryEven.Add(location2);
        locationsBatteryEven.Add(location4);
        locationsBatteryEven.Add(location6);
        locationsBatteryEven.Add(location8);
        locationsBatteryEven.Add(location10);

    }

    void RandomLocate()
    {

        //Debug.Log("length of array" + pickableObjects.Length.ToString());

        for (int i = 0; i < batteries.Length; i++)
        {
            //for each pickable objects assign a location and do the stuff that below
            //Debug.Log(pickableObjects[i].tag + "pickableObjects[i].tag");
            randomNumber = Random.Range(0, 10);

            if (randomNumber % 2 == 0)
            {
                //Debug.Log("even");
                batteries[i].transform.position = locationsBatteryOdd[i];
            }
            else
            {
                //Debug.Log("odd");
                batteries[i].transform.position = locationsBatteryEven[i];
            }
        }
    }

}
