using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour {

    public Transform rightControllerTransform;
    [SerializeField]private LineRenderer lineRenderer;
    private bool isDrawing;
    private List<Vector3> points = new List<Vector3>();
	// Use this for initialization
	void Start () {
   
        if (lineRenderer != null)
        {
            Debug.Log("Found line renderer");
        }
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    StartDrawing();
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    StopDrawing();
        //}

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            StartDrawing();
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            addPoint(rightControllerTransform.position);
        }
	}

    private void addPoint(Vector3 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    public void StartDrawing()
    {
        isDrawing = true;
        points.Clear();

    }
    public void StopDrawing()
    {
        isDrawing = false;
    }
}
