using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HP;
    void Start()
    {
        HP = transform.GetComponent<EnemyData>().getHP();
    }

    public void takeDmg(float dmg)
    {
        if (HP - dmg > 0)
        {
            HP -= dmg;
        }else
        {
            Destroy(gameObject);
        }
    }
}
