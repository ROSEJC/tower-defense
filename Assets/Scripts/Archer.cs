using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero
{
    protected override void Attack()
    {
        
        Speed = 1 * my_player.getBonusArcherSpeed();
        base.Attack();
        
    }
}
