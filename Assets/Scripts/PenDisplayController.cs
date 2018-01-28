using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenDisplayController : MonoBehaviour {

    private Renderer renderer;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void SetColor(Color col)
    {
        renderer.material.SetColor("_Color", col);
        renderer.material.SetColor("_EmissionColor", col);
    }
}
