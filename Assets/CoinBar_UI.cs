using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinBar_UI : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI PlayerCoin_Text;
    float f_playerGold;
    string s_playerGold;
    
    Player my_player;

    long[]filter = new long[3] { 1000000, 1000000000, 1000000000000 };
    private void Start()
    {
        my_player = Player.myPlayer;
    }
    private void Update()
    {
        f_playerGold =(int)my_player.getPlayerGold();
        filteringPlayerGold();
        PlayerCoin_Text.text = s_playerGold;
    }

    void filteringPlayerGold()
    {


        if (f_playerGold >= filter[0] && f_playerGold < filter[1])
        {
            f_playerGold /= filter[0];
            s_playerGold = f_playerGold.ToString() + 'M';

        }else
        {
            s_playerGold = f_playerGold.ToString();
        }
    }
    // this function to avoid when player have too much coin that can make the coin bar to be overflow
}
