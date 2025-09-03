using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Player my_PlayerData;
    bool Attacking = false;

    [SerializeField] float timeAttack;
    float currentTime;

    [SerializeField] float Damage;
    void Start()
    {
        my_PlayerData = Player.myPlayer;
        currentTime = timeAttack;

        Damage = transform.GetComponent<EnemyData>().getDmg();
    }


    private void Update()
    {
        if (Attacking)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Attack();
                currentTime = timeAttack;
            }
        }
    }

    void Attack()
    {
        my_PlayerData.takeDamage(Damage);
    }

    public void startAttack()
    {
        Attacking = true;
    }
    public void stopAttack()
    {
        Attacking = false;
    }
}
