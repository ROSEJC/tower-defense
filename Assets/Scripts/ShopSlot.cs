using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopSlot : MonoBehaviour
{
    public GameObject Item;
    
    public Image skillImage;
    public Image charaterImage;
   
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI price;

    public ShopControl Shop;
    public heroManager my_heroManager;
    public Player my_player;
    public ItemInformationTable itemInforTab;
    public UIManager my_uiManager;

    [SerializeField] GameObject priceBox;
    [SerializeField] Image ItemImg;
    SlotsControl local;
    int address;

    Hero HeroData;
    Tower TowerData;

    public enum SlotType
    {
        HeroSlot,
        TowerSlot
    }
    SlotType slotType;
    // Start is called before the first frame update
    void Start()
    {
        #region Connect
        Shop = ShopControl.Shop;
        my_heroManager = heroManager.instance;
        my_player = Player.myPlayer;
        itemInforTab = ItemInformationTable.instance;
        my_uiManager = UIManager.instance;
        #endregion
        
        
    }

    public void onClick()
    {
        itemInforTab.setShopSlot(this);
        itemInforTab.setItem(Item);

        my_uiManager.turnOnItemInformationTab();
        //spawn a charater in the slot that the player chosen, set its parent is that slot 
        //After that we update the inventory(Active,local,address)
    }

    void getTarget()
    {
        local = Shop.local;
        address = Shop.address;
    }

    void Check()
    {
        local.clearSlot(address);
        if (slotType == SlotType.HeroSlot)
        {
            //Check if the slot is already full or not, if yes, remove current charater of the slot
            if (my_heroManager.checkActive(HeroData.getIdentity().ID))
            {
                my_heroManager.clearHero(HeroData.getIdentity().ID);
            }
        }
        else
        {
            if (my_heroManager.checkActive(TowerData.getTowerData().ID))
            {
                my_heroManager.clearHero(TowerData.getTowerData().ID);
                Debug.Log("Deleted");
            }
        }
        //check if the charater is active or not
        // If isactive remove it at the old slot, spawn at the new slot
    }
    
    public void setItem(GameObject Item, SlotType type)
    {
        this.Item = Item;
        slotType = type;
        


        if (slotType == SlotType.HeroSlot)
        {
            HeroData = this.Item.GetComponent<Hero>();
            updateHeroSlotUI();
            slotType = SlotType.HeroSlot;
            ItemImg.sprite = HeroData.getIdentity().charateAvatar;

            if (heroManager.instance.isPurchased(HeroData.getIdentity().ID))
            {
                priceBox.SetActive(false);
            }
        }
        else if (slotType == SlotType.TowerSlot)
        {
            TowerData = this.Item.GetComponent<Tower>();
            updateTowerSlotUI();
            slotType = SlotType.TowerSlot;

            ItemImg.sprite = TowerData.getTowerData().avt;
            if (heroManager.instance.isPurchased(TowerData.getTowerData().ID))
            {
                priceBox.SetActive(false);
            }
        }
    }

    void updateHeroSlotUI()
    {
        ItemName.text = HeroData.getIdentity().charaterName;
        price.text = HeroData.getIdentity().price.ToString();
    }

    void updateTowerSlotUI()
    {
        ItemName.text = TowerData.getTowerData().TowerName;
        price.text = TowerData.getTowerData().price.ToString();
    }

    public void Equip()
    {
        if (slotType == SlotType.HeroSlot)
        {
            if (!my_heroManager.isPurchased(HeroData.getID()))
            {
                if (my_player.useGold(HeroData.getIdentity().price))
                {
                    my_heroManager.setPurchased(HeroData.getID());
                    priceBox.SetActive(false);
                }
                else
                {
                    return;
                }
            }
        }
        else
        {
            if (!my_heroManager.isPurchased(TowerData.getTowerData().ID))
            {
                if (my_player.useGold(TowerData.getTowerData().price))
                {
                    my_heroManager.setPurchased(TowerData.getTowerData().ID);
                    priceBox.SetActive(false);
                }
                else
                {
                    return;
                }
            }
        }
        getTarget();

        GameObject instance = Instantiate(Item, new Vector3(0, 0, 0), Quaternion.identity);
        Check();
        local.addInstance(address, instance);
    }
}
