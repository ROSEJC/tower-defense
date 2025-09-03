using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveGame : MonoBehaviour
{

    public static SaveGame instance;

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
    private void Start()
    {
        Invoke("LoadData", 1f);
        //LoadData();
    }
    public void SaveData()
   {
        GameData _data = new GameData();

        _data._coin = Player.myPlayer.getGold();
        _data.currentWaveLevel = enemySpawn.enemySpawner.getCurrentRoundLevel();
        
        _data.ArchersLevel = BaseSlotsControl.instance.getCurrentArchersLevel();
        _data.nextArcherToUpgrade = BaseSlotsControl.instance.getNextArcher();
        _data.upgradeArchers_Total = BaseSlotsControl.instance.getTotalUpgradedArcher();

        _data.castleLevel = CastleLevelManager.instance.getCurrentCastleLevel();

       
        _data.allGameItemsInfor = heroManager.instance.getItemsInformation();
        Debug.Log(_data.allGameItemsInfor.Count);

        PlayerPrefs.SetString(key: "GameData", value: JsonUtility.ToJson(_data));
        PlayerPrefs.Save();
   }

    public void LoadData()
    {
        GameData _data = new GameData();
        if (PlayerPrefs.HasKey("GameData"))
        {
            string save = PlayerPrefs.GetString("GameData");
            Debug.Log(save);
            _data = JsonUtility.FromJson<GameData>(save);
        }


       
        Player.myPlayer.loadGold(_data._coin);
        enemySpawn.enemySpawner.loadCurrentRound(_data.currentWaveLevel);

        BaseSlotsControl.instance.setCurrentArchersLevel(_data.ArchersLevel);
        BaseSlotsControl.instance.loadNextArcher(_data.nextArcherToUpgrade);
        BaseSlotsControl.instance.setTotalUpgradedArcher(_data.upgradeArchers_Total);

        CastleLevelManager.instance.setCurrentCastleLevel(_data.castleLevel);

        

        heroManager.instance.loadItemsInformation(_data.allGameItemsInfor);


    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted all PlayerPrefs data");
        LoadData();
    }

}

[System.Serializable]
public class GameData
{
    public float _coin;
    public int castleLevel;
    
    public int[] ArchersLevel;
    public int nextArcherToUpgrade;
    public int upgradeArchers_Total;

    public int currentWaveLevel;

    public List<ItemsDataInformation> allGameItemsInfor;

    public GameData (){
        _coin = 100000;
        castleLevel = 1;
        currentWaveLevel = 0;

        ArchersLevel = new int[20];
        upgradeArchers_Total = 0;

        allGameItemsInfor = new List<ItemsDataInformation>();
        for (int i = 0; i  < 20; i++)
        {
            ArchersLevel[i] = 0;
        }

    }
}