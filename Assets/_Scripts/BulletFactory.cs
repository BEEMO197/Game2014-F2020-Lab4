using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject defaultBullet;
    public GameObject fatBullet;
    public GameObject giantFriendlyBullet;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject createBullet(BulletType type = BulletType.DEFAULT_LINE)
    {
        GameObject tempBullet = null;
        
        switch (type)
        {
            case BulletType.DEFAULT:
                tempBullet = Instantiate(defaultBullet);
                tempBullet.GetComponent<BulletController>().damage = 5;
                break;

            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;

            case BulletType.GIANTFRIENDLYBULLET:
                tempBullet = Instantiate(giantFriendlyBullet);
                tempBullet.GetComponent<GiantFriendlyBullet>().damage = 20;
                break;

            case BulletType.DEFAULT_LINE:
            default:
                if (count == 5)
                {
                    tempBullet = Instantiate(fatBullet);
                    tempBullet.GetComponent<BulletController>().damage = 10;
                    count = 0;
                }
                else
                {
                    tempBullet = Instantiate(defaultBullet);
                    tempBullet.GetComponent<BulletController>().damage = 5;
                }
                break;
        }
        count++;
        return tempBullet;
    }
}
