using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{




    float arcHeight = 2f;
    public override void setTarget(Enemy tar)
    {
        
        if (target != null)
        {

            //Reset();
            //returnToPool();
            Debug.Log("WARNINGGGG");
          //  return;
        }
        base.setTarget(tar);
        currentTime = (Time.time - startTime) / journeyTime;

       
    }

    override protected void Move()
    {
     #region Remove 
        /*if (currentTime <= timeTravel)
        currentTime += Time.deltaTime;


        float percentage = currentTime / timeTravel;
        Vector3 toMid = Vector3.Lerp(orginPos, middlePoint, percentage);
        Vector3 midEnd = Vector3.Lerp(middlePoint, targetPos, percentage);
        oldPosition = currentPos;
        currentPos = Vector3.Lerp(toMid, midEnd, percentage);


        transform.right = currentPos - oldPosition;
        transform.position = currentPos;*/
#endregion
        currentTime = (Time.time - startTime) / journeyTime;
        oldPosition = currentPos;
        currentPos = Vector3.Lerp(orginPos, targetPos, currentTime);
        currentPos.y += Mathf.Sin(Mathf.Clamp01(currentTime) * Mathf.PI) * arcHeight;

        transform.right = currentPos - oldPosition;
        transform.position = currentPos;
    }

   

    public void setArcHeight(float maxHeight)
    {
        arcHeight = maxHeight;
    }

    protected override void returnToPool()
    {
        orginPos = Vector3.zero; // Đặt lại giá trị originPos
        targetPos = Vector3.zero; // Đặt lại giá trị targetPos
        base.returnToPool();
    }

}
