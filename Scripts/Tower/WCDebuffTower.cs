using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WCDebuffTower : MonoBehaviour
{
    [SerializeField]
    private string monsterTag = "Monster";

    [SerializeField]
    private float slowDownRate = 2f;

    //.. Apply Slow Debuff
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == monsterTag)
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed = slowDownRate;
        }
    }

    //.. Debuff clear
    void OnTriggerExit(Collider other)
    {
        if (other.tag == monsterTag)
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed = 5f;
        }
    }


}
