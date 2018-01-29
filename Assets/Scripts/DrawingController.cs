using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawingController : MonoBehaviour {

    public Transform rightControllerTransform;
    [SerializeField] private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    private bool isDrawing;
    private List<Vector3> points = new List<Vector3>();
    private List<GameObject> drawings = new List<GameObject>();

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
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            decreaseWidth();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            increaseWidth();
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
        lineRenderer = Instantiate(drawingPrefab, this.transform).GetComponent<LineRenderer>();
        isDrawing = true;
        points.Clear();
        
    }

    public void StopDrawing()
    {
        isDrawing = false;

    }

    public void increaseWidth()
    {
        if(lineRenderer.widthMultiplier < 1)
        {
          
            lineRenderer.widthMultiplier += (float).005;
        }
      
    }

    public void decreaseWidth()
    {
        if (lineRenderer.widthMultiplier > .001)
        {
          
            lineRenderer.widthMultiplier -= (float).005;
        }
    }

}
