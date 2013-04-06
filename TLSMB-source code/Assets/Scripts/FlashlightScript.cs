using UnityEngine;
using System.Collections;

public class FlashlightScript : MonoBehaviour
{

    public GameObject Enemy;
    EnemyScript mScript;
    public float duration = 1.0F;
    public float beginningFlashlightIntensity;
    private bool lightStabilized;
    public bool flashLightActive;

	// Use this for initialization
	void Start () {
        mScript = Enemy.GetComponent<EnemyScript>();
	    beginningFlashlightIntensity = this.light.intensity;
	    lightStabilized = true;
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(this.light.enabled == true)
            {
                this.light.enabled = false;       //TO-DO turn light off
                flashLightActive = false;
            }
            else if( this.light.enabled == false)
            {
                this.light.enabled = true;        //TO-DO turn light on
                flashLightActive = true;
            }        
        }


        if (mScript.distanceBetween <= mScript.distanceToFollowHighSpeed)
        {
            LightFlicker();
        }
        else
        {
            if(lightStabilized == false)
            {
                CheckLightAfterFlicker();
            }
        }

        if(this.light.enabled == true)
        {
           DecreaseLight();
        }
	}


    void LightFlicker()
    {
        if (Random.value <= 0.3) //a random chance
        {
            if (this.light.enabled == true) //if the light is on...
            {
                this.light.enabled = false;  //turn it off randomly
                lightStabilized = false;
            }
            else
            {
                this.light.enabled = true; //turn it on randomly
                lightStabilized = false;
            }
        }
    }


    void CheckLightAfterFlicker()
    {
        if(flashLightActive == true)
        {
            this.light.enabled = true;
            lightStabilized = true;
        }
        else
        {
            this.light.enabled = false;
            lightStabilized = true;
        }  

    }



    void DecreaseLight()
    {
        if(this.light.intensity > 0.01f)
        {
            this.light.intensity = this.light.intensity - 0.003f;
        }
        else
        {
            this.light.active = false;
            flashLightActive = false;
        }
        
    }

}
