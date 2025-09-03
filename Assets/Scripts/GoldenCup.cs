using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCup : Tower { 
    [SerializeField]float BonusGoldReceive;
    public override void Enable()
    {
        
        my_PlayerData.setBonusGoldReceive(BonusGoldReceive);
        base.Enable();
    } 
    public override void Disable()
    {
       
        my_PlayerData.setBonusGoldReceive(-BonusGoldReceive);
        base.Disable();
    }
}
