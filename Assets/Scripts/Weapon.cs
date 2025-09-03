using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    heroSpecialSkill.specialSkill my_specialSkill;
    [SerializeField] protected Skill specialSkill;
    [SerializeField] protected AudioSource my_audio;
    [SerializeField] protected string soundName;
    public int skillID;
    public float skillCooldown;
    protected bool connected = false;
    protected BulletManager my_BulletManager;
   
    public heroSpecialSkill heroSkillHolder;


    protected virtual void Start()
    {
        my_BulletManager = transform.GetComponent<BulletManager>();
        if(soundName != null)
        {
            my_audio.clip = SoundManager.instance.getClip(soundName);
        }
    }

    public virtual void Attack(Enemy enemy)
    {
        my_audio.Play();
    }
    public virtual void SetSkill()
    {
        if (specialSkill != null)
        {
            my_specialSkill = specialSkill.specialSkill;
            heroSkillHolder.setSkill(my_specialSkill);
        }

    }
    protected virtual void Update()
    {
        if (connected == false && heroSkillHolder != null)
        {
            SetSkill();
            connected = true;
        }
    }
}
