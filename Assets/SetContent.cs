using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetContent : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI content;
    public void setMyContent(string s)
    {
        content.text = s;
    }
    
}
