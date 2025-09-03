using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CastleLevelManager : MonoBehaviour
{
    public static CastleLevelManager instance;

    Player my_player;

    Transform[] WallSlots;
    Transform[] HeroSlots;
    Transform[] TowerSlots;
    
    [SerializeField]private Transform WallControl;
    [SerializeField] private Transform HeroSlotControl;
    [SerializeField] private Transform TowerSlotControl;
    [SerializeField] int currentLevel;
    [SerializeField] CastleUpgradeDatas my_CastleUpgradeData;
    [SerializeField] TextMeshProUGUI price;
    bool[] isActive;

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

    void Start()
    {
        my_player = Player.myPlayer;

        WallSlots = new Transform[WallControl.transform.childCount];
        HeroSlots = new Transform[HeroSlotControl.transform.childCount];
        TowerSlots = new Transform[TowerSlotControl.transform.childCount];

        isActive = new bool[WallControl.childCount];
        for (int i = 0; i  < WallControl.childCount; i++)
        {
            WallSlots[i] = WallControl.GetChild(i);
        }
        for (int i = 0; i  < HeroSlotControl.childCount; i++)
        {
            HeroSlots[i] = HeroSlotControl.GetChild(i);
        }
        
        for (int i = 0; i  < TowerSlotControl.childCount; i++)
        {
            TowerSlots[i] = TowerSlotControl.GetChild(i);
        }

      

        currentLevel = 0;
        upgradeLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel < my_CastleUpgradeData.CastleUpgradeData.Count)
        {
            price.text = my_CastleUpgradeData.CastleUpgradeData[currentLevel].price.ToString();
        }
    }

    public void upgradeLevel()
    {
        if (currentLevel < my_CastleUpgradeData.CastleUpgradeData.Count)
        {
            if (my_player.useGold(my_CastleUpgradeData.CastleUpgradeData[currentLevel].price))
            {
                currentLevel++;
                upgradeCastle(currentLevel);
            }
        }else
        {
            SoundManager.instance.playErrorSound();
            UIManager.instance.turnOnNotificationBox("CASTLE HAS REACHED MAX LEVEL");
        }
    }

    void SetActive(Transform a)
    {
        a.gameObject.SetActive(true);
    }

    void upgradePlayerData()
    {

        my_player.setMaxHealth(my_CastleUpgradeData.CastleUpgradeData[currentLevel - 1].Castle_HP);
        my_player.setMaxMP(my_CastleUpgradeData.CastleUpgradeData[currentLevel - 1].Castle_MP);

    }

    void loadLevel()
    {
        HeroSlotsControl.instance.clearAll();
        TowerSlotsControl.instance.clearAll();

        for (int i = 0; i  < 3; i++)
        {
            
            WallSlots[i].gameObject.SetActive(false);
        } 
        for (int i = 0; i  < 9; i++)
        {
            HeroSlots[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i  < TowerSlotControl.childCount; i++)
        {
            TowerSlots[i].gameObject.SetActive(false);
        }

        for (int i = 1; i <= currentLevel; i++)
        {
            upgradeCastle(i);
        }
    }

    public int getCurrentCastleLevel()
    {
        return currentLevel;
    }
    public void setCurrentCastleLevel(int data)
    {
        currentLevel = data;
        loadLevel();
    }
    void upgradeCastle(int level)
    {
        switch (level)
        {
            case 1:
                {
                    SetActive(WallSlots[0]);
                    SetActive(HeroSlots[0]);
                    SetActive(HeroSlots[1]);
                    SetActive(HeroSlots[2]);
                

                     break;
                }
            case 2:
                {
                    SetActive(WallSlots[1]);
                    SetActive(HeroSlots[4]);

                    break;
                }
            case 3:
                {
                    SetActive(TowerSlots[0]);
                    SetActive(HeroSlots[3]);
                    SetActive(HeroSlots[5]);
                    break;
                }
            case 5:
                {
                    SetActive(WallSlots[2]);
                    SetActive(HeroSlots[7]);
                   
                    break;
                }
            case 6:
                {
                    SetActive(TowerSlots[1]);
                    SetActive(HeroSlots[6]);
                    SetActive(HeroSlots[8]);
                    break;
                }
            default:
            {
              return;
            }

        }
        upgradePlayerData();
    }

}
