using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public BulletFactory bulletFactory;

    public int maxBullets;
    public int maxGiantBullets;

    private Queue<GameObject> m_bullets;
    private Queue<GameObject> m_giantbullets;
    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
        BuildGiantBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildBulletPool()
    {
        m_bullets = new Queue<GameObject>();

        for(int i = 0; i < maxBullets; i++)
        {
            var tempBullet = bulletFactory.createBullet(BulletType.DEFAULT_LINE);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
            m_bullets.Enqueue(tempBullet);
        }
    }

    private void BuildGiantBulletPool()
    {
        m_giantbullets = new Queue<GameObject>();

        for (int i = 0; i < maxGiantBullets; i++)
        {
            var giantTempBullet = bulletFactory.createBullet(BulletType.GIANTFRIENDLYBULLET);
            giantTempBullet.SetActive(false);
            giantTempBullet.transform.parent = transform;
            m_giantbullets.Enqueue(giantTempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bullets.Dequeue();

        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public GameObject GetGiantBullet(Vector3 position)
    {
        var newGiantBullet = m_giantbullets.Dequeue();

        newGiantBullet.SetActive(true);
        newGiantBullet.transform.position = position;
        return newGiantBullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bullets.Enqueue(returnedBullet);
    }

    public void ReturnGiantBullet(GameObject returnedGiantBullet)
    {
        returnedGiantBullet.SetActive(false);
        m_giantbullets.Enqueue(returnedGiantBullet);
    }
}
