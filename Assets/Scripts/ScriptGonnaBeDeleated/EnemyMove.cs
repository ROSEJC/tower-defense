using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float speed = 3;
    float endPointX;
    [SerializeField]private int line;
    EnemyAttack enemyAttack;
    private void Start()
    {
        enemyAttack = transform.GetComponent<EnemyAttack>();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= endPointX){
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
            enemyAttack.stopAttack();
        }else
        {
            enemyAttack.startAttack();
        }
    }
    public void setEndPoint(float pointX)
    {
        endPointX = pointX;
    }

    #region Line
    public int getLine()
    {
        return line;
    }
    
    public void setLine(int l)
    {
        line = l;
    }

    #endregion


}
