using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackArrow_muaTenSkill : BlackArrow
{
    public void setPos(Vector3 pos)
    {
        isTargerted = true;
        orginPos = transform.position;
        targetPos = pos;
        Direction = (targetPos - orginPos).normalized;
    }
    protected override void returnToPool()
    {
        Destroy(gameObject);
    }
    override protected void Update()
    {
        if (transform.position.y >= targetPos.y)
        {
            base.Update();
        }
    }

}
