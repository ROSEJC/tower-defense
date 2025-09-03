using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new charater", menuName = "Charater")]
public class HeroData : ScriptableObject
{
   
    public string charaterName;
    
    public int price;
    public string ID;

    [SerializeField] List<GameObject> head;
    [SerializeField] List<GameObject> body;
    [SerializeField] List<GameObject> weapon;


    [SerializeField] List<int> LevelCheckpoint;

    public Sprite charateAvatar;
    public Sprite skillImage;

    [TextArea]
    public string information;
    
    public int MAX_LEVEL;

    public GameObject getHead(int level)
    {
        for (int i = LevelCheckpoint.Count-1; i >= 0; i--)
        {
            if (level >= LevelCheckpoint[i])
            {
                if (i >= head.Count)
                {
                    return head[head.Count - 1];
                }
                return head[i];
            }
        }
        return null;
    }
    
    public GameObject getBody(int level)
    {
        for (int i = LevelCheckpoint.Count-1; i >= 0; i--)
        {
            if (level >= LevelCheckpoint[i])
            {
                if (i >= body.Count)
                {
                    return body[body.Count - 1];
                }
                return body[i];
            }
        }
        return null;
    }
    
    public GameObject getWeapon(int level)
    {
        for (int i = LevelCheckpoint.Count-1; i >= 0; i--)
        {
            if (level >= LevelCheckpoint[i])
            {
                if (i >= weapon.Count)
                {
                    return weapon[weapon.Count - 1];
                }
                return weapon[i];
            }
        }
        return null;
    }
   
   
}
