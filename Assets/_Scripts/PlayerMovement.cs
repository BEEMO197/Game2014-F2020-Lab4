using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public BulletManager bulletManager;
    public float horizontalSpeed;
    public Touch touchInput;
    public Vector2 currentTouchPosition;
    public Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.touchCount);
        if(Input.touchCount >= 2)
        {
            touchInput = Input.GetTouch(1);
            FireGiantBullet();
            FireBullet();
        }

        else if (Input.touchCount > 0 && Input.touchCount < 2)//&& Input.GetTouch(0).deltaTime < 1.0f)
        {
            touchInput = Input.GetTouch(0);
            FireBullet();
        }

        currentTouchPosition = Camera.main.ScreenToWorldPoint(touchInput.position);
        Debug.Log(currentTouchPosition);

        // Move Ship to Cursor
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, currentTouchPosition.x, 0.1f), transform.position.y);

        // Check where to move
        //if (currentTouchPosition.x > transform.position.x)
        //{
        //    rigidbody.velocity = new Vector2(horizontalSpeed, rigidbody.velocity.y);
        //}
        //else if(currentTouchPosition.x < transform.position.x)
        //{
        //    rigidbody.velocity = new Vector2(-horizontalSpeed, rigidbody.velocity.y);
        //}

        // Check Bounds
        //if (transform.position.x > 2.0f)
        //{
        //    transform.position = new Vector2(2.0f, transform.position.y);
        //}
        //if (transform.position.x < -2.0f)
        //{
        //    transform.position = new Vector2(-2.0f, transform.position.y);
        //}

        // Reset input
        if (Input.touchCount == 0)
        {

        }
    }

    private void FireBullet()
    {
        // Delays The bullet Coming out
        if (Time.frameCount % 5 == 0)
        {
            bulletManager.GetBullet(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
        }
    }

    private void FireGiantBullet()
    {
        bulletManager.GetGiantBullet(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z));
    }
}
