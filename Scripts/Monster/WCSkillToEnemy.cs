using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCSkillToEnemy : MonoBehaviour
{
    [SerializeField]
    private int MeteorDamage = 100;

    public void OnParticleCollision(GameObject go)
    {
        WCMonster go_Monster = this.gameObject.GetComponent<WCMonster>();
        go_Monster.TakeDamage(MeteorDamage);
        if (go_Monster.curMonsterHealthPoint <= 0.0f)
        {
            go_Monster.Death();
        }
    }
}
