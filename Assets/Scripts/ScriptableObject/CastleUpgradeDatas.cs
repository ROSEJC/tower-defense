using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CastleUpgradeDatas : ScriptableObject
{
    public List <UpgradeData> CastleUpgradeData;
}

[System.Serializable]
public class UpgradeData 
{
    public float Castle_HP;
    public float Castle_MP;
    public int price;
}