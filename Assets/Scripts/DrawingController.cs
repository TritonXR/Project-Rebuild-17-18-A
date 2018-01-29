using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour {

    public Transform rightControllerTransform;
    public GameObject drawingPrefab;

    private LineRenderer _currentLineRenderer;
    private bool isDrawing;
    private List<Vector3> points = new List<Vector3>();
	// Use this for initialization
	void Start () {
   
        if (_currentLineRenderer != null)
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
        _currentLineRenderer.positionCount = points.Count;
        _currentLineRenderer.SetPositions(points.ToArray());
    }

    public void StartDrawing()
    {
        //Create a new line renderer that comes with the drawing prefab.
        _currentLineRenderer = Instantiate(drawingPrefab, this.transform).GetComponent<LineRenderer>();

        isDrawing = true;
        points.Clear();

    }
    public void StopDrawing()
    {
        isDrawing = false;
    }
}
