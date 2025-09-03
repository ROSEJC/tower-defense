using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsControl : MonoBehaviour
{
    protected Transform[] slots;
    protected GameObject[] items;

    protected heroManager inventory;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        inventory = heroManager.instance;

        slots = new Transform[transform.childCount];
        items = new GameObject[transform.childCount];
        
       
        
    }

    public void clearAll()
    {
        for (int  i = 0; i < transform.childCount; i++)
        {
            clearSlot(i);
        }
    }
    virtual public void clearSlot(int i)
    {
       
    }

    virtual public void addInstance(int i, GameObject Instance)
    {
       
    }

    public bool isEmpty(int i)
    {
        if (items[i] == null)
        {
            return true;
        }
        return false;
    }

    public GameObject getInstance(int i)
    {
        return items[i];
    }
}
