using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Round", menuName = "Round")]
public class Round : ScriptableObject
{
 
    [SerializeField]List<Enemy> enemies;
    [SerializeField]List<int> amount;
    [SerializeField]List<float> timeSpawn;

    public Enemy getEnemy(int i)
    {
        return enemies[i];
    } public int getAmount(int i)
    {
        return amount[i];
    } public float getTimeSpawn(int i)
    {
        return timeSpawn[i];
    }

    public int getAmountOfEnemyWave()
    {
        return enemies.Count;
    }
}
