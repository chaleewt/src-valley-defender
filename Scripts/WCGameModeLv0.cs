using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCGameModeLv0 : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<WCSoundManager>().PlaySound("MainThemSound");
    }
}
