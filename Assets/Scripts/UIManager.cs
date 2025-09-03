using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Animator upgradeTable;
    [SerializeField] private Animator Shop;
    [SerializeField] private Animator StartButton;
    [SerializeField] private Animator StatusBar;
    [SerializeField] Animator blackBackground;
    [SerializeField] Animator NotificationBox;
    [SerializeField] Animator itemInformationTab;
    [SerializeField] Animator VictoryNotification;
    [SerializeField] Animator DefeatNotification;
    float hidePosX = 1000000;
    float hidePosY = 1000000;

    public static UIManager instance;

    SoundManager my_soundManager;

    public enum UI_State
    {
        loading,
        upgradeTable,
        inGame
    }
    public UI_State uiState, currentState;
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
    private void Start()
    {
        my_soundManager = SoundManager.instance;
    }
    #region MoveUI
    void setUIBack(Animator ui)
    {
        //ui.transform.position = new Vector2(ui.GetComponent<returnOriginPosition>().getX(), ui.GetComponent<returnOriginPosition>().getY());
        ui.gameObject.SetActive(true);
        ui.SetTrigger("turnOn");
    }

    void HideUI(Animator ui)
    {
        //ui.transform.position = new Vector2(hidePosX, hidePosY);

        ui.gameObject.SetActive(false);
    }
    #endregion

    
   
    #region UIState
    private void PrepareUI()
    {
        blackBackground.gameObject.SetActive(false);
        setUIBack(upgradeTable);
        setUIBack(StartButton);
        HideUI(StatusBar);
        HideUI(Shop);
    }
    private void loadingUI()
    {
        HideUI(itemInformationTab);
        HideUI(NotificationBox);
        HideUI(blackBackground);
        HideUI(upgradeTable);
        HideUI(Shop);
        HideUI(StartButton);
        HideUI(StatusBar);
    }
    
    private void InGameUI()
    {
        StatusBar.enabled = true;

        setUIBack(StatusBar);
        HideUI(blackBackground);
        HideUI(upgradeTable);
        HideUI(Shop);
        HideUI(StartButton);
    }
    #endregion


    #region UpdateUI
    public void setUI_State(UI_State state)
    {
        uiState = state;
        changeUI();
    }
    
    void changeUI()
    {
        if (uiState == UI_State.upgradeTable)
        {
            PrepareUI();
        }
        else if (uiState == UI_State.loading)
        {
            loadingUI();

        }
        else if (uiState == UI_State.inGame)
        {
            InGameUI();
        }
    }
    #endregion


    #region Shop UI
    public void OpenHeroUI()
    {
        my_soundManager.playEquipSound();
        setUIBack(Shop);
        setUIBack(blackBackground);
        Shop.gameObject.GetComponent<ShopUI>().openHeroShop();
       
        //Kêu Shop chuyển load các slots của hero slots ra
        //set UI_State thành shop, lúc này Shop tab sẽ hiện ra trên màn hình
        //sau khi shop tab đã hiện ra trên màn hình thì hiện 1 màn hình đen lên làm mờ phần hình ảnh phía sau (cho nó ngầu)
    }
    public void OpenTowerUI()
    {
        my_soundManager.playEquipSound();
        setUIBack(Shop);
        setUIBack(blackBackground);
        Shop.gameObject.GetComponent<ShopUI>().openTowerShop();
       

    }

    public void turnOnNotificationBox(string s)
    {
        setUIBack(NotificationBox);
        NotificationBox.transform.GetComponent<SetContent>().setMyContent(s);
        
    }
    public void turnOffNotificationBox()
    {
        my_soundManager.playButtonSound();
        HideUI(NotificationBox);
    }

    public void turnOffShop()
    {
        my_soundManager.playButtonSound();
        HideUI(Shop);
        HideUI(blackBackground);
    }

    public void turnOnItemInformationTab()
    {
        my_soundManager.playButtonSound();
        setUIBack(itemInformationTab);
    } 
    public void turnOffItemInformationTab()
    {
        my_soundManager.playButtonSound();
        HideUI(itemInformationTab);
    }
    //Not enough gold ui

    public void Victory_UI()
    {
        setUIBack(VictoryNotification);
    } 
    
    public void Defeat_UI()
    {
        setUIBack(DefeatNotification);
    }
    //Shop UI hơi đặt biệt ở chỗ khi mở lên thi phải xác định xem mở Shop nào (Hero, Tower) nên phải tạo hàm riêng, khi gọi hàm riềng uistate sẽ tự động chuyển sang "Buying"
    #endregion
}
