using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed = 0.1f;

    public float direction = 1.0f;

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

    private void Move()
    {
        transform.position += new Vector3(Speed * direction, 0.0f, 0.0f);
    }

    private void CheckBounds()
    {
        if(transform.position.x < -2.0f || transform.position.x > 2.0f)
        {
            direction *= -1;
        }
    }
}
