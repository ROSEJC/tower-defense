using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected int Line;
    
    [SerializeField]protected float Speed;
    [SerializeField]protected float HP;
    [SerializeField]protected int Bounty;
    [SerializeField] protected float dmg;

    protected float currentHP;
    SpriteRenderer spriteRender;
    protected Vector3 endPoint;
    protected Player playerData;
    protected float currentSpeed;
    [SerializeField]Vector3 Direction;
    protected void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
       
        #region Connect
        playerData = Player.myPlayer;
        #endregion
        currentHP = HP;
        currentSpeed = Speed;
    }

    protected override void Attack()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            base.Attack();
            playerData.takeDamage(dmg);
            currentTime = cooldown;
        }

    }
    protected override void Die()
    {
        
        playerData.setGold(Bounty);
        Destroy(gameObject);
    }

    public void activeDie()
    {
        Destroy(gameObject);
    }
    //when you want to clear the game after the player losing but dont want some enemy's special skill to take place when they die.
    void Move()
    {

       
        if (Mathf.Abs(endPoint.y - transform.position.y) > 0.1f)
        {
            Debug.Log("Can duoc dieu chinh");
            Direction = new Vector2(0, endPoint.y) - new Vector2(0, transform.position.y);
        }
        else if (transform.position.x > endPoint.x)
        {
            Direction = (endPoint - transform.position).normalized;
        }else
        {
            Direction = new Vector3(0, 0, 0);
            currentSpeed = 0;
        }
        transform.position += Direction * currentSpeed *Time.deltaTime;
        
    }

    public void setLine(int lineNumber)
    {
        Line = lineNumber;
        if (Line == 0)
        {
            spriteRender.sortingLayerName = "Line 1";
        }else if (Line == 1)
        {
            spriteRender.sortingLayerName = "Line 2";
        }else if (Line == 2)
        {
            spriteRender.sortingLayerName = "Line 3";
        }else if (Line == 3)
        {
            spriteRender.sortingLayerName = "Line 4";
        }
    }

    public void setEndPoint(Vector2 endPointPos)
    {
        endPoint = endPointPos;
    }   
    
    public virtual void takeDmg(float dmg)
    {
        if (currentHP - dmg > 0)
        {
            currentHP -= dmg;
        }else
        {
            Die();
        }
    }


    public float getMaxHP()
    {
        return HP;
    }

    public float getCurrentHP()
    {
        return currentHP;
    }

    public float getCurrentSpeed()
    {
        return currentSpeed;
    }

    private void Update()
    {
        Move();
        if(transform.position.x < endPoint.x + 0.1f)
        {
            Attack();
        }
    }
}
