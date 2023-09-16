using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCValleyGateHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider gateHealthBar;

    [SerializeField]
    private Text gateMaxHealthText;

    [SerializeField]
    private Text gateCurrentHealthText;


    public void SetMaxHealth(int health)
    {
        gateHealthBar.maxValue = health;
        gateHealthBar.value = health;

        gateMaxHealthText.text = "/ " + health.ToString();
        gateCurrentHealthText.text = health.ToString();
    }

    public void SetHealth(int health)
    {
        gateHealthBar.value = health;

        gateCurrentHealthText.text = health.ToString();
    }
}
