using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //if(OVRInput.GetDown)
        if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {

            Debug.Log("right select button is held");
        
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {

            Debug.Log("right select button is released");

        }
    }
}
