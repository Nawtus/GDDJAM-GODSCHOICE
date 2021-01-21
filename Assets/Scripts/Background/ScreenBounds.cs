using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    protected Vector2 Bounds;
    private SpriteRenderer BackRenderer;

    public void GetBackRenderer()
    {
        BackRenderer = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
    }



    public void GetBounds()
    {
        Bounds = new Vector2(BackRenderer.size.x / 2, BackRenderer.size.y / 2);
    }
}
