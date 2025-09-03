using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour
{

    public static ShopControl Shop;

    public SlotsControl local;
    public int address;
    //this is the wall and the index of the slot of the wall that was clicked to open to shop
    heroManager inventory;


    // Start is called before the first frame update
    private void Awake()
    {
        #region Singleton
        if (Shop != null && Shop != this)
        {
            Destroy(this);
        }
        else
        {
            Shop = this;
        }
        #endregion
    }
    void Start()
    {
       
        inventory = heroManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSlot (SlotsControl sl, int index )
    {
        local = sl;
        address = index;

        // nhan vao dia chi cua O Slot duoc click, khi mua 1 charater hoac chon, thi se tim den wall do, dia chi do de them hero
    }
}
