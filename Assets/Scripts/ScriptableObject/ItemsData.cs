using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Items List", menuName = "Items List")]
public class ItemsData : ScriptableObject
{
    public List<GameObject> my_Items;
}
