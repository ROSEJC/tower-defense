using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnOriginPosition : MonoBehaviour
{
    public float CurrentX;
    public float CurrentY;

    void Start()
    {
        CurrentX = transform.position.x;
        CurrentY = transform.position.y;
    }


    public float getX()
    {
        return CurrentX;
    }
    public float getY()
    {
        return CurrentY;
    }
}
