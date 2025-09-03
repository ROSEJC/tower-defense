using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource _audioSourceBGM;
    public AudioSource _audioSourceUI;
    public AudioSource _audioSourceFX;
    [SerializeField]SoundConfigs my_soundConfigs;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }else if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        playBGM();
    }
    public AudioClip getClip(string fileName)
    {
        for (int i = 0; i  < my_soundConfigs.clips.Count; i++)
        {
            if (my_soundConfigs.clips[i].name == fileName)
            {
                return my_soundConfigs.clips[i];
            }
        }
        Debug.Log("Sound not found");
        return null;
    }

    public void playBGM()
    {
        _audioSourceBGM.clip = getClip("bgm");
        _audioSourceBGM.Play();
    }

    public void playCashSound()
    {
        _audioSourceUI.clip = getClip("Cash");
        _audioSourceUI.Play();
    }
    
    public void playErrorSound()
    {
        _audioSourceUI.clip = getClip("Error");
        _audioSourceUI.Play();
    }
    
    public void playButtonSound()
    {
        _audioSourceUI.clip = getClip("Button");
        _audioSourceUI.Play();
    }
    
    public void playEquipSound()
    {
        _audioSourceUI.clip = getClip("Equip");
        _audioSourceUI.Play();
    }
    public void playVictorySound()
    {
        _audioSourceFX.clip = getClip("Victory");
        _audioSourceFX.Play();
    }
    public void playDefeatSound()
    {
        _audioSourceFX.clip = getClip("Defeat");
        _audioSourceFX.Play();
    } 
    

}
