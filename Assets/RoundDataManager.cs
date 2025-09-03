using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundDataManager : MonoBehaviour
{
    public static RoundDataManager instance;

    [SerializeField] List<Round> roundData;
    private void Awake()
    {
        #region Singleton
            if (instance != null && instance != this)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
        #endregion
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Round getRound(int roundIndex)
    {
        return roundData[roundIndex];
    }

    public int getRoundCount()
    {
        return roundData.Count;
    }
    public int getAmountOfEnemyInRound(int roundIndex)
    {
        int s = 0 ;
        for (int i = 0; i  < roundData[roundIndex].getAmountOfEnemyWave(); i++)
        {
            s += roundData[roundIndex].getAmount(i);
        }
        return s;
    }
}
