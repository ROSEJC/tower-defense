using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] float enemyHP;
    [SerializeField] float enemyDmg;
    [SerializeField] float enemyBounty;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHP()
    {
        return enemyHP;
    }

    public float getDmg()
    {
        return enemyDmg;
    }

    public float getBounty()
    {
        return enemyBounty;
    }
}
