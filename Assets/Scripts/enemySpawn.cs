using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public static enemySpawn enemySpawner;

    public Transform endPoint; // the place enemy will stop moving to attack
    public GameObject pathLine; // the line the enemy will go
    Transform[] Line; // Lines that the game has
    int lineCount;// number of lines that the game has

    float currentTime;
    public int currentRoundIndex = 0;
    public int currentWave = 0;
    int enemySpawnedCount;

    public bool inRound = false;
    public bool Spawning = false;

    [SerializeField] private float timeSpawn;
    [SerializeField] int Wave_amountEnemy;
    [SerializeField] float CountTime;   
    EnemyManage my_enemyManager;
    GameState my_gameState;
    Player my_playerData;
    RoundDataManager my_roundData;


    Enemy currentEnemy;

    Round currentRound;

    private void Awake()
    {
        #region Singleton
        if (enemySpawner != this && enemySpawner != null)
        {
            Destroy(this);
        }
        else
        {
            enemySpawner = this;
        }
        #endregion
    }
    void Start()
    {
        #region Connect
        my_enemyManager = EnemyManage.enemyManager;
        my_gameState = GameState.instance;
        my_playerData = Player.myPlayer;
        my_roundData = RoundDataManager.instance;
        #endregion

        Wave_amountEnemy = 0;
        lineCount = pathLine.transform.childCount;
        Line = new Transform[lineCount];
        for (int i = 0; i < lineCount; i++)
        {
            Line[i] = pathLine.transform.GetChild(i);
        }

        currentTime = timeSpawn;

        currentRound = my_roundData.getRound(currentRoundIndex);
    }
    void Update()
    {
        if (my_gameState.getGame_State() == GameState.Game_State.FightingState && Wave_amountEnemy != 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = timeSpawn;
                PassiveSpawn();
                Wave_amountEnemy--;
            }
        }
        else if (Spawning && my_gameState.getGame_State() == GameState.Game_State.FightingState && Wave_amountEnemy == 0)
        {
            //khi da spawn xong 1 wave thi check xem con wave nao khong, neu con thi lay du lieu wave do(enemy, cooldown, amount of enemies in that round)
            if (currentWave <currentRound.getAmountOfEnemyWave())
            {

                currentEnemy = currentRound.getEnemy(currentWave);
                Wave_amountEnemy = currentRound.getAmount(currentWave);
                timeSpawn = currentRound.getTimeSpawn(currentWave);
                currentTime = timeSpawn;

                currentWave++;

            }
            //spawn xong thi reset currentWave ve khong
            else
            {
                currentWave = 0;
                Spawning = false;
            }
        }
    }
    void PassiveSpawn()
    {

        int rand = Random.Range(0, lineCount);
        Enemy instance = Instantiate(currentEnemy, Line[rand].position, Quaternion.identity);
        enemySpawnedCount++;
        instance.setLine(rand);

        Vector3 endPos = new Vector3(endPoint.position.x, Line[rand].position.y);
        instance.setEndPoint(endPos);

        my_enemyManager.enemies.Add(instance);
        my_enemyManager.isChecked.Add(false);
        //Spawn enemy, set the line enemy will go,set the end point, add enemy to the enemy list enemy manager
    }

    public int getAmountEnemy()
    {
        return Wave_amountEnemy;
    }

    public void setWaveAmountEnemy(int amount)
    {
        Wave_amountEnemy = amount;
    }
    public void startGame()
    {
        if (currentRoundIndex < my_roundData.getRoundCount())
        {
            enemySpawnedCount = 0;
            my_gameState.setGameState(GameState.Game_State.CountDownState);
            StartCoroutine(CountDown());
        }
        else
        {
            UIManager.instance.turnOnNotificationBox("YOU HAVE FINISHED THE GAME");
        }

        // neu currentRound = null ---> HET GAME
    }
    public void replay()
    {
        Wave_amountEnemy = 0;
        currentWave = 0;
        Spawning = false;
    }
    public void nextRound()
    {
       
        if (currentRoundIndex + 1< my_roundData.getRoundCount())
        {
            currentRoundIndex++;
            currentRound = my_roundData.getRound(currentRoundIndex);
        }
        else
        {
            currentRoundIndex = my_roundData.getRoundCount();
            currentRound = null;
        }

        // neu con Round thi chuyen len round tiep theo, neu khong thi tra ve null
    }
    

    public int getenemyTotalRound()
    {
        return my_roundData.getAmountOfEnemyInRound(currentRoundIndex);
    }
    //tra ve so Wave trong Round hien tai
    public int getEnemySpawnedCount()
    {
        return enemySpawnedCount;
    }
    //tra ve so enemy da spawn trong round hien tai
    public void ActiveSpawn(Enemy children, int line,Vector3 pos)
    {
        Enemy instance = Instantiate(children, pos, Quaternion.identity);
        instance.setLine(line);

        Vector3 endPos = new Vector3(endPoint.position.x,Line[line].position.y);
        instance.setEndPoint(endPos);

        my_enemyManager.enemies.Add(instance);
        my_enemyManager.isChecked.Add(false);
    }
    //This function is used when a boss want to spawn more enemies that not be included in round data

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(CountTime);
        Spawning = true;
        my_gameState.setGameState(GameState.Game_State.FightingState);
    }


    public void loadCurrentRound(int data)
    {
        currentRoundIndex = data;
        if (currentRoundIndex < my_roundData.getRoundCount())
            currentRound = my_roundData.getRound(currentRoundIndex);
    }

    public int getCurrentRoundLevel()
    {
        return currentRoundIndex;

    }
    //tra ve round hien tai(level)


}

