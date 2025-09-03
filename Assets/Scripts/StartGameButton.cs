using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{

    enemySpawn my_enemySpawn;
    UIManager my_uiManager;
    SoundManager my_soundManager;
    [SerializeField] float currentTime;

    bool click = false;
    private void Start()
    {
        #region Connect
        my_enemySpawn = enemySpawn.enemySpawner;
        my_uiManager = UIManager.instance;
        my_soundManager = SoundManager.instance;
        #endregion
    }

    public void Update()
    { 
      
    }
    public void OnClick()
    {
        my_soundManager.playButtonSound();
        my_enemySpawn.startGame();
    }
}
