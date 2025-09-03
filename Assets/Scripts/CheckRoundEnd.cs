using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRoundEnd : MonoBehaviour
{
    enemySpawn my_enemySpawner;
    EnemyManage my_enemyManager;
    Player my_playerData;
    GameState my_gameState;
    UIManager my_uiManager;
    SoundManager my_soundManager;

    [SerializeField] float countDownTime;
    bool ischecked = false;
    private void Start()
    {
        #region Connect
        my_enemySpawner = enemySpawn.enemySpawner;
        my_enemyManager = EnemyManage.enemyManager;
        my_playerData = Player.myPlayer;
        my_gameState = GameState.instance;
        my_uiManager = UIManager.instance;
        my_soundManager = SoundManager.instance;
        #endregion
    }
    private void Update()
    {
        check();
    }

    void check()
    {
        if (!ischecked)
        {
            if (my_gameState.getGame_State() == GameState.Game_State.FightingState && my_enemySpawner.Spawning == false && my_enemyManager.getEnemiesCount() == 0)
            {
                ischecked = true;
                my_soundManager.playVictorySound();
                my_uiManager.Victory_UI();
                StartCoroutine(WIN());
            }

            if (my_gameState.getGame_State() == GameState.Game_State.FightingState && my_playerData.get_Current_Player_Health() <= 0)
            {
                ischecked = true;
                Debug.Log("Lose");
                my_soundManager.playDefeatSound();
                my_uiManager.Defeat_UI();
                StartCoroutine(Defeat());
            }
        }
        
    }


    IEnumerator WIN()
    {
        yield return new WaitForSeconds(countDownTime);
        my_playerData.win();
        ischecked = false;
    }
    
    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(countDownTime);
        my_playerData.Lose();
        ischecked = false;
    }
   
}
