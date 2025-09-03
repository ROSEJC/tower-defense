using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSlotsControl : SlotsControl
{

    public static HeroSlotsControl instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else
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
            HeroSlotOnClick click = slots[i].transform.GetComponent<HeroSlotOnClick>();
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
            inventory.cleanInformation(items[i].GetComponent<Hero>().getIdentity().ID);
            Destroy(items[i]);
        }
    }

    public override void addInstance(int i, GameObject Instance)
    {
        // base.addInstance(i, Instance);
        Instance.transform.SetParent(slots[i].transform);
        inventory.updateLocation(Instance.GetComponent<Hero>().getIdentity().ID, this, i);
        items[i] = Instance;
        items[i].GetComponent<Hero>().setLevel(1);
        Instance.transform.position = slots[i].position;

    }

}
