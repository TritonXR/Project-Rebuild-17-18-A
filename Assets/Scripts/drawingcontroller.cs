using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingcontroller : MonoBehaviour {

    public GameObject lineRendererobject;

    [SerializeField]private LineRenderer lineRenderer;

    private bool isDrawing;

    // Use this for initialization
    void Start() {

        if (lineRenderer != null) ;

        Debug.Log("Found this line renderer");

        //lineRenderer = lineRendererobject.GetComponent<>
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartDrawing()
    {

        isDrawing = true;

    }

    public void StopDrawing()
    {

        isDrawing = false;

    }




}
