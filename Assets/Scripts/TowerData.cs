using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class TowerData : ScriptableObject
{
    public string ID;
    public string TowerName;
    public int price;
    [TextArea]
    public string information;

    public Sprite avt;

}
