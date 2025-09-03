using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Tower
{
    [SerializeField] float bonusArchersSpeed;
    public override void Enable()
    {
        
        my_PlayerData.setBonusArcherSpeed(bonusArchersSpeed);
        base.Enable();
    } 
    public override void Disable()
    {
        my_PlayerData.setBonusArcherSpeed(-bonusArchersSpeed);
        base.Disable();
    }
}
