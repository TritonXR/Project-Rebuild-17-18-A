using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRUtils;

public class DrawingController : MySingleton<DrawingController> {

    /// <summary>
    /// Stores all the drawings.
    /// </summary>
    private List<GameObject> drawings;

    /// <summary>
    /// The prefab to create when a new drawing is created.
    /// </summary>
    public GameObject drawingPrefab;

    /// <summary>
    /// The current drawing to add points to when drawing has been started.
    /// </summary>
    private LineRenderer currentDrawing;

    /// <summary>
    /// Stores the points of a drawing.
    /// </summary>
    private List<Vector3> points = new List<Vector3>();

    /// <summary>
    /// What color to draw in.
    /// </summary>
    private Color color = Color.red;

    /// <summary>
    /// Flags whether drawing has been started.
    /// </summary>
    private bool isDrawingStarted = false;

    private void Start()
    {
        VRControllerInput.Instance.OnSelectButtonDown += (HandType hand) =>
        {
            if (hand == HandType.RIGHT)
                StartDrawing();
        };
        VRControllerInput.Instance.OnSelectButtonUp += (HandType hand) =>
        {
            if (hand == HandType.RIGHT)
                FinishDrawing();
        };
    }

    public void SetColor(string colName)
    {
        switch (colName)
        {
            case "red":
                color = Color.red;
                break;
            case "green":
                color = Color.green;
                break;
            case "blue":
                color = Color.blue;
                break;
            default:
                color = Color.white;
                break;
        }

        if (currentDrawing != null)
        {
            currentDrawing.startColor = color;
            currentDrawing.endColor = color;
        }
    }

    public void StartDrawing()
    {
        isDrawingStarted = true;
        points.Clear();
        currentDrawing = Instantiate(drawingPrefab, this.transform).GetComponent<LineRenderer>();
        currentDrawing.startColor = color;
        currentDrawing.endColor = color;
    }

    public void FinishDrawing()
    {
        isDrawingStarted = false;
        currentDrawing = null;
    }

    private void addPoint(Vector3 pos)
    {
        points.Add(pos);
        currentDrawing.positionCount = points.Count;
        currentDrawing.SetPositions(points.ToArray());
    }

    private void Update()
    {
        if (isDrawingStarted)
        {
            addPoint(VRControllerInput.Instance.GetControllerPosition(HandType.RIGHT));
        }
    }
}
