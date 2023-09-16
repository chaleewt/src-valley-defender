using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCPath : MonoBehaviour
{
    [System.NonSerialized]
    public Transform[] waypoints;

    void Awake()
    {
        GetPathPoints();
    }

    public void GetPathPoints()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
