using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed = 0.3f;
    void Update()
    {
        transform.position += (new Vector3(11, transform.position.y) - transform.position).normalized * Time.deltaTime * speed;

        if (transform.position.x >= 11)
        {
            transform.position = new Vector2(-11 , transform.position.y);
        }
    }
}
