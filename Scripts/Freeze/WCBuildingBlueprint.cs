using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCBuildingBlueprint : MonoBehaviour
{
    public GameObject transparantPrefab;

    public void SpawnBuildingBlueprint()
    {
        Instantiate(transparantPrefab);
    }
}
