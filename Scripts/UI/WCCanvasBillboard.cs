using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCCanvasBillboard : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;

    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}
