using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HP_UI_Script : MonoBehaviour
{
    Player myPlayer;
    float percentage;
    [SerializeField]Image HP_bar;
    [SerializeField]TextMeshProUGUI HP_count;

    void Start()
    {
        myPlayer = Player.myPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        percentage = myPlayer.getCurrent_Health() / myPlayer.getMax_Health();
        HP_bar.fillAmount = percentage;
        HP_count.text = myPlayer.getCurrent_Health().ToString();
    }
}
