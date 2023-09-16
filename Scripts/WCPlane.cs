using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCPlane : MonoBehaviour
{
    [System.NonSerialized]
    public bool planeIsOccupied = false;

    public void PlanIsOccupied()
    {
        gameObject.SetActive(false);
        planeIsOccupied = true;
    }
}
