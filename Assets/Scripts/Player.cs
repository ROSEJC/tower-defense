using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player myPlayer;

    float maxHealth;
    float currentHealth;

    float maxMP;
    float currentMP;

    [SerializeField]float playerGold;

    int tempGold = 0;
    GameState my_gameState;
    EnemyManage my_enemyManage;
    enemySpawn my_enemySpawn;
    UIManager my_uiManager;
    SoundManager my_soundManager;
    #region BonusStats

    [SerializeField] float BonusArchersSpeed = 0;
    [SerializeField] float BonusGoldReceived = 0;
    [SerializeField] float BonusHP = 0;
    [SerializeField] float BonusMP = 0;
    #endregion



    private void Awake()
    {
        #region Singleton
        if (myPlayer != null && myPlayer != this)
        {
            Destroy(this);
        }
        else
        {
            myPlayer = this;
        }
        #endregion
    }
    private void Start()
    {
        #region Connect
        my_gameState = GameState.instance;
        my_enemyManage = EnemyManage.enemyManager;
        my_enemySpawn = enemySpawn.enemySpawner;
        my_uiManager = UIManager.instance;
        my_soundManager = SoundManager.instance;
        #endregion
        currentHealth = maxHealth;

        //playerGold = 100;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(float damageTake)
    {
        if (my_gameState.getGame_State() == GameState.Game_State.FightingState)
        {
            if (currentHealth - damageTake  > 0 )
            {
                currentHealth -= damageTake;
            }else
            {
                currentHealth = 0;
                tempGold = 0;
            }
        }
    }

    public void setGold(int gold)
    {
        tempGold += gold;
    }

    public bool useGold(float gold)
    {
        if (playerGold - gold < 0)
        {
            Debug.Log("SUMIMASEN. YOU DONT HAVE ENOUGH MONEY :(");
            my_soundManager.playErrorSound();
            my_uiManager.turnOnNotificationBox("NOT ENOUGH GOLD");
            return false;
        }else
        {
            if (gold != 0)
            {
                my_soundManager.playCashSound();
            }
            playerGold -= gold;
            return true;
        }
    }
    public void win()
    {
        currentHealth = maxHealth;
        playerGold += (tempGold + tempGold * BonusGoldReceived);
        tempGold = 0;
       
        my_enemySpawn.nextRound();
        my_gameState.setGameState(GameState.Game_State.PrepareState);
    }
    public void Lose()
    {
        my_enemySpawn.replay();
        currentHealth = maxHealth;
        my_gameState.setGameState(GameState.Game_State.PrepareState);
        my_enemyManage.clearEnemy();
    }

    public float get_Current_Player_Health()
    {
        return currentHealth;
    }

    public float getMax_Health()
    {
        return maxHealth;
    }

    public float getCurrent_Health() 
    {
        return currentHealth;
    }

    public float getPlayerGold()
    {
        return playerGold;
    }

    public void setMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public void setMaxMP(float MP)
    {
        maxMP = MP;
        currentMP = maxMP;
    }

    public float getBonusArcherSpeed()
    {
        return BonusArchersSpeed;
    }

    public void setBonusArcherSpeed(float p)
    {
        BonusArchersSpeed += p;
        if (BonusArchersSpeed < 1)
        {
            BonusArchersSpeed = 1;
        }
    }

    public void setBonusGoldReceive(float p)
    {
        BonusGoldReceived += p;
        if (BonusGoldReceived < 0)
        {
            BonusGoldReceived = 0;
        }
    }

    public float getGold()
    {
        return playerGold;
    }

    public void loadGold(float data)
    {
        playerGold = data;
    }
}
