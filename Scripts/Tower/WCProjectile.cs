using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCProjectile : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private int projectileDamage = 20;

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private GameObject hitEffect;

    [System.NonSerialized]
    public bool isInAir;

    void Awake()
    {
        isInAir = true;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void Seek(Transform monsterTarget)
    {
        if (target == null)
        {
            target = monsterTarget;
        }
    }

    void HitTarget()
    {
        Vector3 hitLocationOffset = new Vector3(0, 5.5f, 0);
        GameObject effectInstance = (GameObject)Instantiate(hitEffect, transform.position + hitLocationOffset, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(gameObject);
    }

    //.. Apply damage to Monster
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster" || other.tag == "Terrian")
        {
            HitTarget();
            WCMonster monster = other.GetComponent<WCMonster>();
            if (monster)
            {
                monster.TakeDamage(projectileDamage);

                if (monster.curMonsterHealthPoint <= 0.0f)
                {
                    monster.Death();
                }
            }
        }
    }
}
