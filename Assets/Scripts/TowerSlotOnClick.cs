using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlotOnClick : MonoBehaviour
{

    UIManager ui;
    GameState gameState;

    public int address;
    public SlotsControl sl;

    public ShopControl shopControl;
    void Start()
    {
        #region Connect
        ui = UIManager.instance;
        gameState = GameState.instance;
        #endregion
        if (GameObject.Find("GameManager"))
            shopControl = GameObject.Find("GameManager").GetComponent<ShopControl>();
    }
    public void setAddress(int index)
    {
        address = index;
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameState.getGame_State() == GameState.Game_State.PrepareState)
            {
                ui.OpenTowerUI();
                shopControl.setSlot(sl, address);
            } //If player click on Tower slot, check if Game_State is prepare state lets player open shop, else lets player use charater's especial skills


        }
    }
}
