using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSlotOnClick : MonoBehaviour
{
    UIManager ui;
    GameState gameState;
    
    public int address;
    public SlotsControl sl;
    
    public ShopControl shopControl;
 
    // Start is called before the first frame update
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
    // Update is called once per frame
    void Update()
    {
    }



    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (gameState.getGame_State() == GameState.Game_State.PrepareState)
            {
                if (gameState.getGame_State() == GameState.Game_State.PrepareState) {
                    ui.OpenHeroUI();
                }
                shopControl.setSlot(sl, address);
            } //If player click on Wall slot, check if Game_State is prepare state lets player open shop, else lets player use charater's especial skills
            else if (gameState.getGame_State() == GameState.Game_State.FightingState)
            {
                useSpecialSkill();
            }
           
        }

    }


   
    void useSpecialSkill()
    {
        GameObject temp = sl.getInstance(address);
        if (temp != null)
        {
            temp.GetComponent<Hero>().useSkill();
            Debug.Log("Use Skill");
        }
    }
}
