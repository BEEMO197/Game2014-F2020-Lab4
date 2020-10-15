using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFriendlyBullet : MonoBehaviour, IApplyDamage
{
    public BulletManager bulletManager;
    public float bulletSpeed = 1.0f;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, bulletSpeed, 0.0f);

        if (transform.position.y > 5.0f)
        {
            bulletManager.ReturnGiantBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {

        }
        else
        {
            bulletManager.ReturnGiantBullet(gameObject);

        }
    }

    public int ApplyDamage()
    {
        throw new System.NotImplementedException();
    }
}
