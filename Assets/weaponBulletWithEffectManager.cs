using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBulletWithEffectManager : BulletManager
{
    [SerializeField] protected BulletWithEffect myBullet;
    [SerializeField] protected private Queue<BulletWithEffect> pooledObject = new Queue<BulletWithEffect>();
    public override void CreatePool()
    {
        // Kiểm tra xem đã tồn tại một pool cho prefab này chưa

        for (int i = 0; i < poolSize; i++)
        {
            BulletWithEffect temp = Instantiate(myBullet, transform.position, Quaternion.identity);
            temp.bulletManager = this;
            pooledObject.Enqueue(temp);
            temp.ArrowSpriteOff();

        }
    }

    public override Bullet GetPooledObject()
    {
        if (pooledObject.Count <= 0)
        {
            CreatePool();
        }
        BulletWithEffect temp = pooledObject.Dequeue();
        temp.ArrowSpriteOn();
        return temp;

    }

    public override void ReturnObjectToPool(Bullet obj)
    {

        if (!obj.hasReturned)
        {
            ((BulletWithEffect)obj).ArrowSpriteOff();

            pooledObject.Enqueue((BulletWithEffect)obj);
        }
    }
}
