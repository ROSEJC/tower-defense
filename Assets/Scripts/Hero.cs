using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{

    
    protected EnemyManage enemyManager;
    protected Player my_player;
    [SerializeField]protected float Speed = 1;

    float heroMana;
    [SerializeField] protected int weaponSkillID;
    [SerializeField] float skillCoolDown;
    protected float currentSkillTime;

    protected override void Start()
    {
        base.Start();
        #region Connect
        enemyManager = EnemyManage.enemyManager;
        my_player = Player.myPlayer;

        #endregion
    }
    void clearBody(Transform a)
    {
        for (int i = 0; i < a.childCount; i++)
        {
            Destroy(a.GetChild(i).gameObject);
        }
    }
    public void setIdentity()
    {
        clearBody(headPos);
        clearBody(bodyPos);
        clearBody(weaponPos);

        //remove the old skin and weapon before changeing to the new skin, weapon

        GameObject myHead = Instantiate(charater.getHead(currentLevel), headPos.position, Quaternion.identity);
        GameObject myBody = Instantiate(charater.getBody(currentLevel), bodyPos.position, Quaternion.identity);

        GameObject weaponTemp = Instantiate(charater.getWeapon(currentLevel), weaponPos.position, Quaternion.identity);
        //spawn new skin and weapon

        myHead.transform.SetParent(headPos);
        myBody.transform.SetParent(bodyPos);
        weaponTemp.transform.SetParent(weaponPos);
        //set parent for the new skin and weapon for easily access to when we want to remove them

        weaponAttack = weaponTemp.GetComponent<Weapon>();

        weaponSkillID = weaponAttack.skillID;
        currentSkillTime = weaponAttack.skillCooldown;

        /*if (transform.GetComponent<heroSpecialSkill>())
        {
            weaponAttack.heroSkillHolder = transform.GetComponent<heroSpecialSkill>();
        }*/
        //connect the weapon with skill holder of character, so that the character can access to the special skill of the weapon and use it 

        identityName = charater.name;
        price = charater.price;
    }

    public void setLevel(int level)
    {

        currentLevel = level;
        setIdentity();

    }

    protected override void Attack()
    {
        // base.Attack();
        if (Aim == null)
        {
            chooseEnemy();

        }
        if (Aim != null)
        {
            setTargetForSpecialSkill();
            weaponAttack.Attack(Aim);
        }
    }
    public void useSkill()
    {
        if (weaponSkillID != -1)
        {
            SkillManager.instance.ActivateSkill(weaponSkillID);
        }
    }

    private void Update()
    {
        currentSkillTime -= Time.deltaTime;
        currentTime -= Time.deltaTime * Speed;
        if (currentTime <= 0f)
        {
            Attack();
            currentTime = cooldown;
        }
    }
    protected void chooseEnemy()
    {
        if (enemyManager.inRange.Count != 0)
        {
           
            int index = Random.Range(0, enemyManager.inRange.Count - 1);
            Aim = enemyManager.inRange[index];
        }
    }

    public string getID()
    {
        return charater.ID;
    }

    
}
