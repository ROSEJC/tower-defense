using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroAttack : MonoBehaviour
{
    /*Charater charater;

    [SerializeField] float attackTime;
    [SerializeField] float currentTime;

    [SerializeField] WeaponAttack weapon;

    EnemyManage enemyManager;

    GameObject Aim;

    public delegate void specialSkill();
    public specialSkill my_specialSkill;
    void Start()
    {
        enemyManager = EnemyManage.enemyManager;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = attackTime;
            if (Aim == null)
            {
                chooseEnemy();
            }
            else
            {
                weapon.targetPos = Aim.transform.position;
                weapon.Fire();
            }
            
        }
    }

    

    void chooseEnemy()
    {
        if (enemyManager.inRange.Count != 0)
        {
            int index = Random.Range(0, enemyManager.inRange.Count - 1);
            Aim = enemyManager.inRange[index];
        }
    }

    public void setSkill(specialSkill skill)
    {
        my_specialSkill = skill;
    }

    public void useSkill()
    {
        if (my_specialSkill != null) my_specialSkill();
    }

    public void setWeapon(WeaponAttack wp)
    {
        weapon = wp;
    }*/
}
