using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour {

    public Transform rightControllerTransform;
    [SerializeField] private LineRenderer lineRenderer;
    private bool isDrawing;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {

        if (lineRenderer != null)
        {
            Debug.Log("Found line renderer");
        }

    }

    void Update ()
    {
        if(isDrawing)
        {
            addPoint(rightControllerTransform.position);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            StartDrawing();
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            StopDrawing();
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
