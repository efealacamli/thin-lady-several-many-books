using UnityEngine;
using System.Collections;

public class PickObject : MonoBehaviour
{

    public bool cameraCanBeChanged;
    public Vector3 cameraPositionToBeMoved;
    public GameObject Light;
    FlashlightScript mScript;
    public int objectPickedCount;
    public bool objectPicked;

	// Use this for initialization
	void Start ()
	{
	    mScript = Light.GetComponent<FlashlightScript>();
	    cameraCanBeChanged = false;
	}
	
	// Update is called once per frame
	void Update () {


	}

    void OnTriggerEnter(Collider other)
    {

        if(other.tag=="PickableObject")
        {
            //Debug.Log(other.tag + " object picked");
            cameraPositionToBeMoved.z = other.transform.position.z;
            //Debug.Log("z pos:" + cameraPositionToBeMoved.z);
            other.active = false;
            cameraCanBeChanged = true;
            objectPickedCount=objectPickedCount + 1;
            objectPicked = true;
            //Debug.Log("object picked count " + objectPickedCount );
        }

        else if(other.tag=="Battery")
        {
            //Debug.Log(other.tag + " object picked");
            other.active = false;
            mScript.light.intensity = mScript.beginningFlashlightIntensity;
            mScript.light.active = true;
            mScript.flashLightActive = true;
        }

    }

}
