using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenTipDisplayController : MonoBehaviour {
    float initLocalScale;
    void Awake()
    {
        initLocalScale = this.transform.localScale.x;
    }

    public void SetPenTipWidth(float width)
    {
        this.transform.localScale = Vector3.one * width;
    }
}
