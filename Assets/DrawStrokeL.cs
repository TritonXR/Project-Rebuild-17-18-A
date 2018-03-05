using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStrokeL : MonoBehaviour
{
    // Use this for initialization
    public Transform parent;
    LineRenderer current_line = null;
    int length_of_curr = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Debug.Log("Lbutton down");
            draw();
        }
        else
        {
            current_line = null;
            length_of_curr = 0;
        }
    }
    public void draw()
    {
        if (current_line == null)
        {
            current_line = new LineRenderer();
            current_line.transform.parent = parent;
        }
        Debug.Log(current_line);
        current_line.SetPosition(length_of_curr++, this.transform.position);
    }
}
