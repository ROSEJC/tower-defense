using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float dmg;
    [SerializeField] protected float timeDestroy;
    [SerializeField] protected int ID;
    [SerializeField] protected float journeyTime;

    protected float currentTime;
    protected float startTime;

    protected Vector3 currentPos;
    protected Vector3 oldPosition;
    protected Vector3 orginPos;
    protected Vector3 targetPos;
   

    protected Transform target;

    protected bool isTargerted = false;//to check if the bullet has it's destination or not, if yes, start moving, use this for unexpected bugs
    protected bool isGrounded = false;//to check if the bullet has already grounded or not, if grounded, stop moving, stop taking dmg
    public bool hasReturned;
    public BulletManager bulletManager;
    virtual protected void hit(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().takeDmg(dmg);
        isGrounded = true;
        returnToPool();
    }

    protected void Reset()
    {
        isTargerted = false;
        target = null;
    }
    virtual protected void Update()
    {
        if (!isGrounded && isTargerted)
        {
            Move();
        }
        if (Vector2.Distance(transform.position, targetPos) < 0.2f)
        {
            Reset();
            isGrounded = true;
            StartCoroutine(waitToDestroy());
        }

    }
    virtual protected IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(timeDestroy);
        returnToPool();
    }

    virtual protected void returnToPool()
    {
        Reset();
        bulletManager.ReturnObjectToPool(this);
        hasReturned = true;

    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isGrounded)
        {
            hit(collision.gameObject);
        }

        if (collision.CompareTag("Deadline"))
        {
            returnToPool();
        }
    }

    virtual protected void Move()
    {

    }
    public virtual void setTarget(Enemy tar)
    {
        target = tar.gameObject.transform;
        startTime = Time.time;
        orginPos = transform.position;
        isTargerted = true;

        targetPos = new Vector3(target.position.x - (tar.getCurrentSpeed() * journeyTime),target.position.y,target.position.z);
        isGrounded = false;
        hasReturned = false;
    }

    public int getID()
    {
        return ID;
    }
}
