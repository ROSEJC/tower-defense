using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalBullet : Bullet
{

    [SerializeField] float Speed;
    Vector3 Direction;
    protected override void Move()
    {
        transform.position += Direction * Speed * Time.deltaTime;
        transform.right = Direction;
    }

    public override void setTarget(Enemy tar)
    {
        base.setTarget(tar);
        Direction = (target.position - orginPos).normalized;
    }
    override protected void Update()
    {
        if (isTargerted)
        {
            Move();
        }
    }

    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hit(collision.gameObject);
        }else if (collision.CompareTag("Deadline"))
        {
            returnToPool();
        }
    }
}
