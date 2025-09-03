using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSlotsControl : MonoBehaviour
{
    public static BaseSlotsControl instance;

    public Transform[] slots;
    protected Hero[] archers;
    [SerializeField]private int[] currentArchersLevel;
    [SerializeField] int goldIncrease;

    int nextArcher;
    int ArcherUpgraded_Total;
    int maxLevel;

    [SerializeField] GameObject archer;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }


        
    }

    void Start()
    {
        slots = new Transform[transform.childCount];
        archers = new Hero[transform.childCount];
        currentArchersLevel = new int[transform.childCount];
        maxLevel = archer.GetComponent<Hero>().getIdentity().MAX_LEVEL;

        for (int i = 0; i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i);
        }
    }
    public void spawnArcher(int i, GameObject Hero)
    {
        Hero.transform.SetParent(slots[i].transform);
        archers[i] = Hero.GetComponent<Hero>();
        //Hero.transform.position = slots[i].position;
    }

    public bool isEmpty(int i)
    {
        if (archers[i] == null)
        {
            return true;
        }
        return false;
    }

    public void upgradeArcher()
    {
        if (isEmpty(nextArcher))
        {
            GameObject instance = Instantiate(archer, slots[nextArcher].position, Quaternion.identity);
            spawnArcher(nextArcher, instance);

            currentArchersLevel[nextArcher] = 1;
            archers[nextArcher].setLevel(currentArchersLevel[nextArcher]);


        }
        else
        {

            currentArchersLevel[nextArcher]++;
            archers[nextArcher].setLevel(currentArchersLevel[nextArcher]);
        }
     
        nextArcher++;
        ArcherUpgraded_Total++;
        if (nextArcher >= slots.Length) nextArcher = 0;
    }

   public bool canUpgrade()
    {
        return currentArchersLevel[nextArcher] < maxLevel;
    }
    void loadBase()
    {
        for (int i = 0; i  < 20; i++)
        {
            if (currentArchersLevel[i] != 0)
            {
                GameObject instance = Instantiate(archer, slots[i].position, Quaternion.identity);
                spawnArcher(i, instance);
                archers[i].setLevel(currentArchersLevel[i]);
            }else
            {
                if (archers[i] != null)
                Destroy(archers[i].transform.gameObject);
            }
        }
    }

    public int[] getCurrentArchersLevel()
    {
        return currentArchersLevel;
    }

    public void setCurrentArchersLevel(int[] data) {
        currentArchersLevel = data;
        loadBase();
    }

    public int getNextArcher()
    {
        return nextArcher;
    }
    
    public void setTotalUpgradedArcher(int data)
    {
        ArcherUpgraded_Total = data;
    }
    public int getTotalUpgradedArcher()
    {
        return ArcherUpgraded_Total;
    }
    public void loadNextArcher(int data)
    {
        nextArcher = data;
    }
    public float getCurrentPrice()
    {
        return (ArcherUpgraded_Total + 1) * goldIncrease;
    }
}
