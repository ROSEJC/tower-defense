using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalWeaponBulletManager : BulletManager
{
    [SerializeField] protected Bullet myBullet;
    [SerializeField] protected private Queue<Bullet> poolObject = new Queue<Bullet>();
    public override void CreatePool()
    {
        // Kiểm tra xem đã tồn tại một pool cho prefab này chưa

        for (int i = 0; i  < poolSize; i++)
        {
            Bullet temp = Instantiate(myBullet, transform.position, Quaternion.identity);
            temp.bulletManager = this;
            poolObject.Enqueue(temp);
            temp.gameObject.SetActive(false);
           
        }
    }

    public override Bullet GetPooledObject()
    {
        if (poolObject.Count <= 0)
        {
            CreatePool();
        }
        Bullet temp = poolObject.Dequeue();
        temp.gameObject.SetActive(true);
        return temp;

    }

    public override void ReturnObjectToPool(Bullet obj)
    {
        if (!obj.hasReturned)
        {
            obj.gameObject.SetActive(false);

            poolObject.Enqueue(obj);
        }
    }

   

}
