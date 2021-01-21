using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bondaries : ScreenBounds
{
    void Start()
    {
        GetBackRenderer();
        GetBounds();
    }



    void Update()
    {
        SetBondaries();
    }



    void SetBondaries()
    {
        Vector3 viewPos = this.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, Bounds.x* -1, Bounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, Bounds.y* - 1.2f, 2f);
        this.transform.position = viewPos;
    }
}
