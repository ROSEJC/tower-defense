using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataButton : MonoBehaviour
{

    public void resetData()
    {
        if (GameState.instance.getGame_State() == GameState.Game_State.PrepareState)
        {
            SoundManager.instance.playButtonSound();
            SaveGame.instance.DeleteAllData();
            UIManager.instance.turnOnNotificationBox("RESET DATA SUCCESSFULLY!");
        }
        else
        {
            UIManager.instance.turnOnNotificationBox("RESETTING IS NOT AVAILABLE NOW!");
        }

    }
}
