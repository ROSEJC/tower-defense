using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManagement : MonoBehaviour
{
    [SerializeField]List<Sprite>skin;
    SpriteRenderer spriteRender;

    [SerializeField] List<int> levelCheckpoint;
    //if level reach these checkpoint, the skin will change

    private void Awake()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }
    public void upgradeSkin(int level)
    {
        int skinIndex = 0;
        for (int i = levelCheckpoint.Count - 1; i >= 0; i--)
        {
            if (level >= levelCheckpoint[i])
            {
                skinIndex = i;
                break;
            }
        }
        if (spriteRender != null && skinIndex < skin.Count && skin[skinIndex] != null)
        {
            spriteRender.sprite = skin[skinIndex];
            Debug.Log("Level: "+ level+"Update skin " + skinIndex + " successful");

        }else if(spriteRender == null)
        {
            Debug.Log("Not found");
        }else if(skinIndex >= skin.Count)
        {
            Debug.Log("OUT");
        }else if (skin[skinIndex] == null)
        {
            Debug.Log("Skin not found");
        }
        
    }
    
}
