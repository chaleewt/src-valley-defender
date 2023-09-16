using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCMonsterHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider monsterHeathBar;

    public void SetMaxHealth(int health)
    {
        monsterHeathBar.maxValue = health;
        monsterHeathBar.value = health;
    }

    public void SetHealth(int health)
    {
        monsterHeathBar.value = health;
    }
}
