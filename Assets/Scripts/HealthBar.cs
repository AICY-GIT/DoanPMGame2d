using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillbar;
    public TextMeshProUGUI HealthValue;
    public void UpdateBar(int currentValue ,int maxValue)
    {
        fillbar.fillAmount= (float)currentValue/(float)maxValue;
        HealthValue.text = currentValue.ToString()+" / "+maxValue.ToString();
    }
}
