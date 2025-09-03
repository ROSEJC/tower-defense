using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ArrowSkill : Skill
{
    

    public override void specialSkill(Enemy enemy, Transform parent)
    {
        
        Bullet instance = Instantiate(bullet, parent.position, Quaternion.identity);
        if (instance != null)
        {
            instance.GetComponent<Bullet>().setTarget(enemy);
        }
        Debug.Log(parent.name + " used skill");
    }
}
