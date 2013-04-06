using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour {

    public GameObject MainCharacter;
    private GameObject mainCamera;
    private GameObject cameraForPickedObject;
    PickObject mScript;
    private Vector3 cameraPositionZ;


    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraForPickedObject = GameObject.FindGameObjectWithTag("CameraForPickedObject");
    }


	// Use this for initialization
	void Start () {
        mScript = MainCharacter.GetComponent<PickObject>();
	}
	
	// Update is called once per frame
	void Update () {
	


        if (mScript.cameraCanBeChanged == true)
        {
            //Debug.Log("Change the camera");
            mainCamera.active = false;

            //move camera-change the camera's z position to pickedobject's z position
            cameraForPickedObject.transform.position = new Vector3(cameraForPickedObject.transform.position.x, cameraForPickedObject.transform.position.y,
                                                     mScript.cameraPositionToBeMoved.z);
            cameraForPickedObject.active = true;

            if (Input.GetMouseButtonDown(1))
            {
                //Debug.Log("Pressed left click.");
                mainCamera.active = true;
                cameraForPickedObject.active = false;
                mScript.cameraCanBeChanged = false;
            }
        }
	}   

    void OnGUI()
    {
        if (mScript.cameraCanBeChanged == true)
        {
            GUI.Label(new Rect(10, 500, 100, 60), "Press right click to exit");
        }
    }


}
