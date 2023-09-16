using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCGhostTower : MonoBehaviour
{
    [SerializeField] Renderer towerMaterial;

    //.. Stored Plan Postion Data
    [System.NonSerialized] public Vector3 placePosition;

    private WCPlane plane;

    void Awake()
    {
        towerMaterial.material.color = Color.red;
    }

    void Update()
    {
        if (plane)
        {
            if (plane.planeIsOccupied)
            {
                towerMaterial.material.color = Color.red;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Placeable")
        {
            //.. Get Plan Position Data
            GetPlanPosition(other.transform.position);
            towerMaterial.material.color = Color.green;

            //.. Cast reference
            plane = other.GetComponent<WCPlane>();
            if (plane)
            {
                plane.planeIsOccupied = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Placeable")
        {
            towerMaterial.material.color = Color.red;
            plane = null;
        }
    }

    void GetPlanPosition(Vector3 t)
    {
        placePosition = t;
    }
}
