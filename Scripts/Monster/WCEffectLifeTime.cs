using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCEffectLifeTime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 3f;

    void LateUpdate()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
