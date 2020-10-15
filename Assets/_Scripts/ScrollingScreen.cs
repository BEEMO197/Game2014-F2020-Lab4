using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScrollingScreen : MonoBehaviour
{
    public float verticalSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

    }


    private void Reset()
    {
        transform.position = new Vector3(0.0f, 4.8f, 0.0f);
    }

    private void Move()
    {
        Vector3 MovetoLocation = new Vector3(0.0f, transform.position.y - verticalSpeed, 0.0f);
        transform.position = MovetoLocation;
    }

    private void CheckBounds()
    {
        if (transform.position.y <= -5.0f)
        {
            Reset();
        }
    }

}
