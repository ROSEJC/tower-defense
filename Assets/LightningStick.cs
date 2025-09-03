using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStick : Weapon
{
    
    public override void Attack(Enemy enemy)
    {
        base.Attack(enemy);
        Bullet instance = my_BulletManager.GetPooledObject();
        // Bullet instance = Instantiate(bullet, transform.position, Quaternion.identity);

        instance.transform.position = transform.position;

        rotate(enemy.transform.position);

        instance.setTarget(enemy);
    }
    void rotate(Vector3 enemyPos)
    {
        Vector3 lookingPoint = (enemyPos - transform.position) / 2;
        transform.up = (lookingPoint - transform.position);
    }
}
