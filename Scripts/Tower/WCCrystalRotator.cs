using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCCrystalRotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 300f;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }
}
