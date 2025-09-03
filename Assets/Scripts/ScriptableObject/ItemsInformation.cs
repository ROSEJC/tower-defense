using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInformation :ScriptableObject
{
    public int ID;
    public int maxAmount;
    public int currentAmount;

    public bool isActive;

    public SlotsControl local;
    public int address;

    public int currentLevel = 1;

}
