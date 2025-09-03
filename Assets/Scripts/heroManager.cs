using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class heroManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static heroManager instance;
    
    private List<ItemsDataInformation> itemsInformation;
    [SerializeField] ItemsData heroList;
    [SerializeField] ItemsData towerList;

    


    void Awake()
    {
        #region Singleton
            if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        #endregion
        itemsInformation = new List<ItemsDataInformation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadItems()
    {

        if (itemsInformation.Count == 0)
        {
            Debug.Log("Load new information");
            for (int i = 0; i < heroList.my_Items.Count; i++)
            {
                AddHeroInformation(heroList.my_Items[i]);
            }

            for (int i = 0; i < towerList.my_Items.Count; i++)
            {
                AddTowerInformation(towerList.my_Items[i]);
            }
        }
        else
        {
            for (int i = 0; i  < itemsInformation.Count; i++)
            {
                if (itemsInformation[i].local != null)
                {
                    
                        GameObject instance = Instantiate(itemsInformation[i].itemInstance);
                        itemsInformation[i].local.addInstance(itemsInformation[i].address, instance);
                    
                }
            }
        }
        sort();
    }

    //This function get character and add its informations into inventory
    public void AddHeroInformation(GameObject hero)
    {
        ItemsDataInformation newItem = new ItemsDataInformation();
        HeroData charComponent = hero.GetComponent<Hero>().getIdentity();

        newItem.itemInstance = hero;
        newItem.ID = charComponent.ID;
        newItem.isActive = false;
        newItem.purchased = false;
        newItem.currentLevel = 1;

        itemsInformation.Add(newItem);
        

    }

    public void AddTowerInformation(GameObject tower)
    {
        ItemsDataInformation newItem = new ItemsDataInformation();
        TowerData temp = tower.GetComponent<Tower>().getTowerData();

        newItem.itemInstance = tower;
        newItem.ID = temp.ID;
        newItem.isActive = false;
        newItem.purchased = false;
        newItem.currentLevel = 1;

        itemsInformation.Add(newItem);
    }

    void sort()
    {
        for (int i = 0; i  < itemsInformation.Count; i++)
        {
            for (int j = i  + 1; j < itemsInformation.Count; j++)
            {
                if (itemsInformation[i].ID.CompareTo(itemsInformation[j].ID) > 0)
                {
                    ItemsDataInformation tempInfor = itemsInformation[i];
                    itemsInformation[i] = itemsInformation[j];
                    itemsInformation[j] = tempInfor;
                }
            }
        }
    }
    //Will update to a better sort function soon...

    public int findAddress(string ID)
    {
        //always sort the list ascendently before searching...
        int left = 0, right = itemsInformation.Count;
        int mid = 0;
        while (left <= right)
        {
            mid = (left + right) / 2;
            if (itemsInformation[mid].ID.CompareTo(ID) < 0) left = mid + 1;
            else if (itemsInformation[mid].ID.CompareTo(ID) > 0) right = mid - 1;
            else return mid;
          
        }
        return mid;
    }

    public bool checkActive(string ID)
    {
        int address = findAddress(ID);
        return itemsInformation[address].isActive;
    }

    // This function update informations of a character
    public void updateLocation(string ID, SlotsControl local, int address)
    {
        int index = findAddress(ID);

        itemsInformation[index].isActive = true;
        itemsInformation[index].local = local;
        itemsInformation[index].address = address; 
    }

    public void cleanInformation (string ID)
    {
        int address = findAddress(ID);
       
        itemsInformation[address].isActive = false;
        itemsInformation[address].local = null;
        itemsInformation[address].address = 0;
    }
    public GameObject GetCharaters(int i)
    {
        return heroList.my_Items[i];
    }
    public int getHeroAmount()
    {
        return heroList.my_Items.Count;
    }


    public void clearHero(string ID)
    {
        int temp = findAddress(ID);
        itemsInformation[temp].local.clearSlot(itemsInformation[temp].address);
    }

    public void updateLevel(string ID,int level)
    {
        int temp = findAddress(ID);
        itemsInformation[temp].currentLevel = level;
    }

    public int getCurrentLevel(string ID)
    {
        int temp = findAddress(ID);
        return itemsInformation[temp].currentLevel;
    }

    public bool isPurchased(string ID)
    {
        int index = findAddress(ID);
        return itemsInformation[index].purchased;
    }

    public void setPurchased(string ID)
    {
        int index = findAddress(ID);
        itemsInformation[index].purchased = true;
    }

    public List <ItemsDataInformation> getItemsInformation()
    {
        //Debug.Log(itemsInformation.Count);
        return itemsInformation;
    }

    public void loadItemsInformation(List <ItemsDataInformation> data)
    {
        itemsInformation = data;
        //Debug.Log(data.Count);
        loadItems();
    }
}

[System.Serializable]
public class ItemsDataInformation
{
    public GameObject itemInstance;
    public string ID;

    public bool isActive;
    public bool purchased;

    public SlotsControl local;
    public int address;

    public int currentLevel = 1;
}