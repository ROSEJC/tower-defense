using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] float timeLoading;
    public enum Game_State
    {
        loadingState,
        PrepareState,
        CountDownState,
        FightingState
    }
    public static GameState instance;
   
    private Game_State State;
    private UIManager UI;
    private void Awake()
    {
        #region Singleton
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        #endregion
    }
    void Start()
    {
        #region Connect
        UI = UIManager.instance;
        #endregion
        StartCoroutine(LoadingMode());
       
    }


    public Game_State getGame_State()
    {
        return State;
    }
    IEnumerator LoadingMode()
    {
        yield return new WaitForSeconds(0.1f);
        setGameState(Game_State.loadingState);
        yield return new WaitForSeconds(timeLoading);
        setGameState(Game_State.PrepareState);
    }
    #region States
    public void loading()
    {
        UI.setUI_State(UIManager.UI_State.loading);
    }
    public void preparing()
    {
        UI.setUI_State(UIManager.UI_State.upgradeTable);
    }
    public void CountDown()
    {
        UI.setUI_State(UIManager.UI_State.inGame);
    }
    #endregion


    #region Update State
    public void updateGameState()
    {
        if (State == Game_State.loadingState) loading();
        else if (State == Game_State.PrepareState) preparing();
        else if (State == Game_State.CountDownState) CountDown();
    }

    public void setGameState(Game_State state)
    {
        State = state;
        updateGameState();
    }
    #endregion
}
