using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlotsControl : SlotsControl
{
    public static TowerSlotsControl instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i);
            TowerSlotOnClick click = slots[i].transform.GetComponent<TowerSlotOnClick>();
            if (click)
            {
                click.setAddress(i);
                //chuyen cho slot do dia chi cua no trong mang
                click.sl = this;
                // cho slot do co the ket noi voi noi kiem soat (SLotsControl)
            }

        }
    }
    public override void clearSlot(int i)
    {
        //base.clearSlot(i);
        if (items[i] != null)
        {
            inventory.cleanInformation(items[i].GetComponent<Tower>().getTowerData().ID);
            items[i].GetComponent<Tower>().Disable();
        }
    }

    public override void addInstance(int i, GameObject Instance)
    {
        // base.addInstance(i, Instance);
        Instance.transform.SetParent(slots[i].transform);
        inventory.updateLocation(Instance.GetComponent<Tower>().getTowerData().ID, this, i);
        items[i] = Instance;
       
        Instance.transform.position = slots[i].position;

    }

}
