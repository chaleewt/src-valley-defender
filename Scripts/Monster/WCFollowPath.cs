using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WCFollowPath : MonoBehaviour
{
    private Transform pathTarget;
    private int pointIndex = 0;

    WCWaveSpawnerManager waveManager;
    NavMeshAgent navAgent;

    WCPath path;

    public void GetPath(WCPath pt)
    {
        path = pt;
    }

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        if (path)
        {
            pathTarget = path.waypoints[pointIndex];
        }
    }

    void Update()
    {
        navAgent.SetDestination(pathTarget.position);
        if (navAgent.remainingDistance <= 0.5)
        {
            GetNextPoint();
        }
    }

    void GetNextPoint()
    {
        if (pointIndex >= path.waypoints.Length - 1)
        {
            return;
        }

        pointIndex++;
        pathTarget = path.waypoints[pointIndex];
    }
}
