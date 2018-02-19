using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStroke : MonoBehaviour {
	// Use this for initialization
	public GameObject player;
	public LineRenderer current_line = null;
	public int length_of_curr = 0;
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown (OVRInput.RawButton.RIndexTrigger)) {
			draw ();
		} else {
			current_line = null;
			length_of_curr = 0;
		}
	}
	public void draw(){
		if(current_line == null){
			current_line = GameObject.Find("Lines").AddComponent<LineRenderer>();
		}
		current_line.SetPosition (length_of_curr++, OVRInput.GetLocalControllerPosition( OVRInput.Controller.RTouch));
	}
}
