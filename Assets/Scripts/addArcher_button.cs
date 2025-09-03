using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class addArcher_button : MonoBehaviour
{
    [SerializeField] private GameObject ArcherSlots;
    [SerializeField] private TextMeshProUGUI upgradedTimeCount;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI buttonName;

    BaseSlotsControl sl;

    Player my_player;
    // Start is called before the first frame update
    void Start()
    {
        sl = ArcherSlots.GetComponent<BaseSlotsControl>();
        #region Connect 
        my_player = Player.myPlayer;
        #endregion

        
    }

    // Update is called once per frame
    void Update()
    {
        if (sl.getTotalUpgradedArcher() >= 20)
        {
            buttonName.text = "UPGRADE ARCHER";
        }
        upgradedTimeCount.text = sl.getTotalUpgradedArcher().ToString();
        price.text = sl.getCurrentPrice().ToString();

    }

    public void onClicked()
    {
        summon();
    }

    void summon()
    {
        if (sl.canUpgrade())
        {

            if (my_player.useGold(sl.getCurrentPrice()))
            {
                sl.upgradeArcher();
            }
        }else
        {
            UIManager.instance.turnOnNotificationBox("ARCHER HAS REACHED MAX LEVEL");
            SoundManager.instance.playErrorSound();
        }
        //Neu co tien thi mua !!!
        //Whenever player click the button, check which slot is empty and spawn an identity at that slot, make that identity's charater to be archer 
    }
}
