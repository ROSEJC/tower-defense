using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManage : MonoBehaviour
{
    public static EnemyManage enemyManager;

    public List<Enemy> enemies; // all the enemy that is in the game
    public List<bool> isChecked;// to check if the enemy hasnt been check to be add in enemyInRange
    public List<Enemy> inRange;

    [SerializeField] private Transform range;


   
    private void Awake()
    {
        #region Singleton
        if (enemyManager != null && enemyManager != this)
        {
            Destroy(this);
        }
        else
        {
            enemyManager = this;
        }
        #endregion
    }
    void Start()
    {
      

        enemies = new List<Enemy>();
        isChecked = new List<bool>();
        inRange = new List<Enemy>(); 

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i  < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                if (enemies[i].transform.position.x < range.position.x && isChecked[i] == false)
                {
                    isChecked[i] = true;
                    inRange.Add(enemies[i]);
                }
            }else
            {
                enemies.RemoveAt(i);
                isChecked.RemoveAt(i);
            }
        }

        for (int i = 0; i  < inRange.Count; i++)
        {
            if (inRange[i] == null) inRange.RemoveAt(i);
        }
        
    }


    public void clearEnemy()
    {
       for (int i = 0; i  < enemies.Count; i++)
       {
            Enemy instance = enemies[i];
            if (instance != null)
            {
                instance.GetComponent<Enemy>().activeDie();
            }
             
       }
        
    }

   public int getEnemiesCount()
    {
        return enemies.Count;
    }
}
