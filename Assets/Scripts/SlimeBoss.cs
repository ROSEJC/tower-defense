using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : Enemy
{
    enemySpawn my_enemySpawn;
    [SerializeField]Enemy smallSlime;
    protected override void Start()
    {
        base.Start();
        my_enemySpawn = enemySpawn.enemySpawner;
    }
    protected override void Die()
    {
        
        skill();
        base.Die();
    }

    void skill()
    {

        my_enemySpawn.ActiveSpawn(smallSlime, 0, transform.position);
        my_enemySpawn.ActiveSpawn(smallSlime, 1, transform.position);
        my_enemySpawn.ActiveSpawn(smallSlime, 2, transform.position);
        my_enemySpawn.ActiveSpawn(smallSlime, 3, transform.position);
    }

}
