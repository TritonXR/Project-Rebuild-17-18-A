using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawStrokeR : MonoBehaviour
{
    // Use this for initialization
    public Transform parent;
    LineRenderer current_line = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            draw();
        }
        else
        {
            current_line = null;
        }
    }
    public void draw()
    {
        if (current_line == null)
        {
            GameObject g = new GameObject();
            g.transform.parent = parent;
            current_line = g.AddComponent<LineRenderer>();
            current_line.startWidth = current_line.endWidth = 0.01f;
            current_line.positionCount = 0;
            
        }
        current_line.positionCount++;
        current_line.SetPosition(current_line.positionCount-1, this.transform.position);
        Debug.Log("Setting position" + (current_line.positionCount - 1));
        //Debug.Log(current_line.positionCount);
        if (current_line.positionCount % 20 == 0 && current_line.positionCount > 10) {
            current_line.Simplify(0.001f);
        }
        //Debug.Log(current_line.GetPosition(0));

    }
}
