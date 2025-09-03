using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    GameState gameState;
    Animator anim;
    float timeDisapear = 5f;
    private void Start()
    {
        gameState = GameState.instance;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if ( gameState.getGame_State() == GameState.Game_State.PrepareState)
        {
            anim.SetTrigger("Disappear");
            StartCoroutine(disapear());
        }
    }
    
    IEnumerator disapear()
    {
        yield return new WaitForSeconds(timeDisapear);
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
