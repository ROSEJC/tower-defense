using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigArmor : Bullet
{
    Vector3 Direction;
    [SerializeField] Vector3 Force;
    bool targeted = false;
    protected override void hit(GameObject enemy)
    {
        base.hit(enemy);
        enemy.transform.position += Force;
        Destroy(gameObject);

    }
    override protected void Move()
    {
        if (target == null) Destroy(gameObject);
        Direction = target.position - transform.position;
        transform.right = Direction;
        //transform.position += Direction * Speed * Time.deltaTime;
        
    }

    override protected void Update()
    {
        if (target != null)
        {
            Move();
            targeted = true;
        }else if (target == null && targeted)
        {
            Destroy(gameObject);
        }
    }

    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (target != false)
        {
            if (collision.gameObject == target.gameObject)
            {
                hit(target.gameObject);
            }
        }else
        {
            Destroy(gameObject);
        }
    }
}
