using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RoundStatus_UI : MonoBehaviour
{
    enemySpawn my_enemySpawn;
    GameState my_gameState;

    Animator myAnimator;

    [SerializeField]TextMeshProUGUI RoundCount;
    [SerializeField]Image StatusBar;


    private void Start()
    {
        #region Connect
        my_enemySpawn = enemySpawn.enemySpawner;
        my_gameState = GameState.instance;
        #endregion
        myAnimator = transform.GetComponent<Animator>();
    }

    private void Update()
    {
        RoundCount.text = ("Wave " + (my_enemySpawn.getCurrentRoundLevel() + 1));
        if (my_gameState.getGame_State() == GameState.Game_State.FightingState)
        {
            myAnimator.enabled = false;
            float percentage = (float)(my_enemySpawn.getenemyTotalRound() - my_enemySpawn.getEnemySpawnedCount()) / (float)my_enemySpawn.getenemyTotalRound();
            StatusBar.fillAmount = Mathf.Lerp(0, 1, percentage);
        }
        
    }
}
