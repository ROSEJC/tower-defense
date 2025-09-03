using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] Enemy parent;
    [SerializeField] Vector3 Offset;

    [SerializeField] Image Slider;

    float percentage;
    private void Start()
    {
        transform.position = Camera.main.WorldToScreenPoint(parent.transform.position + Offset);
    }
    private void Update()
    {
        percentage = parent.getCurrentHP() / parent.getMaxHP();
        Slider.fillAmount = percentage;
 
        transform.position = Camera.main.WorldToScreenPoint(parent.transform.position + Offset);

    }
}
