using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected Player my_PlayerData;
    [SerializeField] TowerData my_Data;
    protected void Start()
    {
        my_PlayerData = Player.myPlayer;
        Enable();
    }
    virtual public void Enable()
    {

    }
    
    virtual public void Disable()
    {
        Destroy(this.gameObject);
    }

    public TowerData getTowerData()
    {
        return my_Data;
    }
}
