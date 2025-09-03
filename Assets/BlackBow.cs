using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBow : Weapon
{
    public override void Attack(Enemy enemy)
    {
        base.Attack(enemy);
        Bullet instance = my_BulletManager.GetPooledObject();
       
        ((BlackArrow)instance).effectOff();
        instance.transform.position = transform.position;
        ((BlackArrow)instance).effectOn();
        // turn partical system off to not make the effect to appear when teleporting

        rotate(enemy.gameObject.transform.position);

        instance.setTarget(enemy);
    }

    void rotate(Vector3 pos)
    {
        transform.right = pos - transform.position;
    }
}
