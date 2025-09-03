using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skill : ScriptableObject
{
    [SerializeField]protected Bullet bullet;
   public virtual void specialSkill(Enemy enemy, Transform parent)
   {

   }
}
