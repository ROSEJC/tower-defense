using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeKing : Enemy
{
    [SerializeField] Enemy slimeBoss;
    Vector3 pos = new Vector3(15.23f, -0.79f, 0);
    float count;

    public override void takeDmg(float dmg)
    {
        base.takeDmg(dmg);
        count += dmg;
        check();
    }

    void check()
    {
        if (count >= HP * (0.25f))
        {
            int rand = Random.Range(0, 4);
            if (rand != Line) {
                enemySpawn.enemySpawner.ActiveSpawn(slimeBoss, rand, pos);
                count = 0;
            }

        }
    }
}
