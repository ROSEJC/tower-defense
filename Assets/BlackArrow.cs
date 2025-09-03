using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackArrow : BulletWithEffect
{
    [SerializeField] float Speed;

   

    protected Vector3 Direction;
    protected override void Move()
    {
        if (Vector3.Distance(targetPos, transform.position) <= 0.5f)
        {
            isGrounded = true;
            Reset();
        }
        
        if (!isGrounded)
        {
            transform.position += Direction * Speed * Time.deltaTime;
            transform.right = Direction;
        }else
        {

            StartCoroutine(waitToDestroy());
        }
    }

    public override void setTarget(Enemy tar)
    {
        if (target != null)
        {
            Debug.Log("Black arrow error");
        }
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
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Deadline"))
        {
            returnToPool();
        }



    }
    protected override void hit(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().takeDmg(dmg);
    }


}
