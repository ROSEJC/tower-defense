using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected HeroData charater;
    protected string identityName;
    protected int price;


    [SerializeField] protected Transform headPos;
    [SerializeField] protected Transform bodyPos;
    [SerializeField] protected Transform weaponPos;

    protected SkinManagement headSkinManager;
    protected SkinManagement bodySkinManager;

    protected Weapon weaponAttack;
    public bool isAlive = true;

    [SerializeField] protected float cooldown;
    protected float currentTime;


    protected Enemy Aim;
    protected heroSpecialSkill my_heroSpecialSkill;
    protected int maxLevel;

    [SerializeField]protected int currentLevel = 1;
    int currentSkinLevel;
    

    heroManager my_inventory;
    virtual protected void Start()
    {
        maxLevel = charater.MAX_LEVEL;
        //setLevel(1);
        my_heroSpecialSkill = transform.GetComponent<heroSpecialSkill>();
        currentTime = cooldown + Random.Range(0,0.5f);
    }

   

    
    protected void setTargetForSpecialSkill()
    {
        my_heroSpecialSkill.setSpecialSkillAim(Aim);
    }

    public void checkSkinIndex()
    {
        headSkinManager.upgradeSkin(currentLevel);
    }
    virtual protected void Attack()
    {

    } 
    virtual protected void Die()
    {

    }
    virtual public HeroData getIdentity()
    {
        return charater;
    }
    public int getCurrentLevel()
    {
        return currentLevel;
    }
    

   

    




}
