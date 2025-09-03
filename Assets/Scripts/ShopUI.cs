using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private ShopSlot slot;
    [SerializeField] private GameObject container;

    [SerializeField] ItemsData my_HeroData;
    [SerializeField] ItemsData my_TowerData;

    [SerializeField] TextMeshProUGUI ShopName;
    heroManager inventory;
    private ShopSlot[] ShopSlots;
    void Start()
    {
        inventory = heroManager.instance;
        //openHeroShop();
    }
    void clearShop()
    {
        for (int i = 0; i  < container.transform.childCount; i++)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
    }
    public void openHeroShop()
    {
        clearShop();
        ShopName.text = "HERO SHOP";
        for (int i = 0; i  < my_HeroData.my_Items.Count; i++)
        {
            ShopSlot temp = Instantiate(slot, container.transform);
            temp.setItem(my_HeroData.my_Items[i], ShopSlot.SlotType.HeroSlot);
        }

    }

    public void openTowerShop()
    {
        clearShop();
        ShopName.text = "TOWER SHOP";
        for (int i = 0; i < my_TowerData.my_Items.Count; i++)
        {
            ShopSlot temp = Instantiate(slot, container.transform);
            temp.setItem(my_TowerData.my_Items[i],ShopSlot.SlotType.TowerSlot);
        }
    }



}
