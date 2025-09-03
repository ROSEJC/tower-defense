using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    
    [SerializeField] bool[] skillCheck;
    [SerializeField] string[] skillSound;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject[] Lines;
    [SerializeField] AudioSource skills_Audio;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else
        {
            instance = this;
        }
    }
    public void Start()
    {
        muaTen_currentTime = muaTen_SkillCooldown;
    }
    public void Update()
    {
        MuaTen_Skill();
    }

    [Header("Mua Ten Skill")] 
    [SerializeField] float height;
    [SerializeField] int skillID_MuaTen;
    [SerializeField] float MuaTen_shootCoolDown;
    float muaTen_currentShootCoolDown;
    [SerializeField] float muaTen_SkillCooldown;
    float muaTen_currentTime;
    [SerializeField] blackArrow_muaTenSkill blackArmor;
    [SerializeField] float deviation;

    void MuaTen_Skill()
    {
       
        if (skillCheck[skillID_MuaTen])
        {
            muaTen_currentTime -= Time.deltaTime;
            muaTen_currentShootCoolDown -= Time.deltaTime;
            if (muaTen_currentShootCoolDown <= 0)
            {
                Vector3 pos = new Vector3(Random.Range(endPoint.position.x, startPoint.position.x), Lines[Random.Range(0, 4)].transform.position.y - 0.5f, endPoint.position.z);
                Vector3 SpawnPos = new Vector3(pos.x - deviation, pos.y + height, endPoint.position.z);
                blackArrow_muaTenSkill instance = Instantiate(blackArmor, SpawnPos, Quaternion.identity);
                instance.setPos(pos);
                muaTen_currentShootCoolDown = MuaTen_shootCoolDown;
            }
            if (muaTen_currentTime <= 0)
            {
                skillCheck[skillID_MuaTen] = false;
                muaTen_currentTime = muaTen_SkillCooldown;
            }

        }
    }
    

    public void ActivateSkill(int skillID)
    {
        skillCheck[skillID] = true;
        skills_Audio.clip = SoundManager.instance.getClip(skillSound[skillID]);
        skills_Audio.Play();
    }

}
