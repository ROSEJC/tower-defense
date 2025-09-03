using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroSpecialSkill : MonoBehaviour
{
    [SerializeField] bool needTarget = true;
    public delegate void specialSkill(Enemy target, Transform parent);
    specialSkill my_specialSkill;
    Enemy SpecialSkillAim;

    public void setSkill(specialSkill skill)
    {
        my_specialSkill = skill;
        Debug.Log("Connect successfully");
    }

    public void useSkill()
    {
        if (needTarget && SpecialSkillAim == null)
        {
            Debug.Log("Chua co target");
            return;
        }else if (needTarget && SpecialSkillAim != null)
        {
            Debug.Log("Da co aim");
            if (my_specialSkill != null)
                my_specialSkill(SpecialSkillAim,transform);
        }else if (!needTarget)
        {
            Debug.Log("Khong can aim");
            if (my_specialSkill != null)
            {
                my_specialSkill(null,transform);
            }
        }
    }
   
    public void setSpecialSkillAim(Enemy target)
    {
        SpecialSkillAim = target;
    }
  
    public void setNeedTarget(bool a)
    {
        needTarget = a;
    }
    public bool isNeedAim()
    {
        return needTarget;
    }
}
