using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameButton : MonoBehaviour
{
    public void saveGame()
    {
        if (GameState.instance.getGame_State() == GameState.Game_State.PrepareState)
        {
            SoundManager.instance.playButtonSound();
            SaveGame.instance.SaveData();
            UIManager.instance.turnOnNotificationBox("GAME SAVED SUCCESSFULLY!");
        }else
        {
            UIManager.instance.turnOnNotificationBox("SAVING IS NOT AVAILABLE NOW!");
        }

    }
}
