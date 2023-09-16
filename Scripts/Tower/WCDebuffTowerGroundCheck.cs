using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCDebuffTowerGroundCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Placeable")
        {
            other.GetComponent<WCPlane>().PlanIsOccupied();
        }
    }
}
