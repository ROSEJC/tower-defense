using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemInformationTable : MonoBehaviour
{
    public static ItemInformationTable instance;

    ShopSlot sl;
    GameObject item;
    [SerializeField]TextMeshProUGUI information_Text;
    [SerializeField]TextMeshProUGUI itemName_text;
    [SerializeField]Image Item_Img;

    [SerializeField] TextMeshProUGUI buttonName;
    [SerializeField] Image ItemImage; 

    Tower towerData;
    Hero HeroData;
    private void Awake()
    {
        if (instance != null &&  instance != this)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
    }
    public void setShopSlot(ShopSlot shopSlot)
    {
        sl = shopSlot;
    }

    public void setItem(GameObject Item)
    {
        item = Item;
        HeroData = item.GetComponent<Hero>();
        
        
        if (HeroData == null)
        {
            towerData = item.GetComponent<Tower>();
            
            information_Text.text = towerData.getTowerData().information;
            itemName_text.text = towerData.getTowerData().TowerName;
            ItemImage.sprite = towerData.getTowerData().avt;
            
            if (heroManager.instance.isPurchased(Item.GetComponent<Tower>().getTowerData().ID))
            {
                buttonName.text = "EQUIP";
            }else
            {
                buttonName.text = "BUY";
            }
        }
        else
        {
            information_Text.text = HeroData.getIdentity().information;
            itemName_text.text = HeroData.getIdentity().charaterName;
            ItemImage.sprite = HeroData.getIdentity().charateAvatar;


            if (heroManager.instance.isPurchased(Item.GetComponent<Hero>().getIdentity().ID))
            {
                buttonName.text = "EQUIP";
            }
            else
            {
                buttonName.text = "BUY";
            }

        }
    }

    public void Equip()
    {

        sl.Equip();
        
    }
}
