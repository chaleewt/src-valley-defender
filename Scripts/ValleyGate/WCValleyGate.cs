using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WCValleyGate : MonoBehaviour
{
    [SerializeField] private GameObject onDestroyParticle;
    [SerializeField] private GameObject onBurnParticle;

    [SerializeField] Image getHealthBarFill;
    WCValleyGateHealthBar gateHealthBar;

    WCCameraShake camShake;

    [SerializeField]
    int maxGateHealthPoint = 100;
    int curGateHealthPoint;

    bool isDestroy, isVictory;


    void Awake()
    {
        gateHealthBar = FindObjectOfType<WCValleyGateHealthBar>();
        camShake = FindObjectOfType<WCCameraShake>();

        if (onBurnParticle)
        {
            onBurnParticle.SetActive(false);
        }
    }

    void Start()
    {
        curGateHealthPoint = maxGateHealthPoint;
        gateHealthBar.SetMaxHealth(maxGateHealthPoint);
    }

    void Update()
    {
        if (curGateHealthPoint <= 0)
        {
            GateDestroy();
        }

        if (curGateHealthPoint <= (maxGateHealthPoint / 2))
        {
            onBurnParticle.SetActive(true);
            getHealthBarFill.color = Color.yellow;
        }

        if (curGateHealthPoint <= (maxGateHealthPoint / 4))
        {
            getHealthBarFill.color = Color.red;
        }
    }

    public void TakeDamage(int dmg)
    {
        curGateHealthPoint -= dmg;
        gateHealthBar.SetHealth(curGateHealthPoint);

        FindObjectOfType<WCSoundManager>().PlaySound("BombSound");
    }

    void GateDestroy()
    {
        isDestroy = true;
        FindObjectOfType<WCSceneLoader>().LoadGameOverCanvas();
        FindObjectOfType<WCSoundManager>().sounds[1].audioSource.volume = 0;
        StartCoroutine(FreezeTime());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            int dmg = other.GetComponent<WCMonster>().damageToGate;
            TakeDamage(dmg);

            GameObject onDestroyParticleGO = Instantiate(onDestroyParticle, transform);
            if (onDestroyParticleGO)
            {
                Destroy(onDestroyParticleGO, 1.5f);
            }

            if (isDestroy || isVictory)
            {
                return;
            }
            else
            {
                StartCoroutine(camShake.Shake(0.5f, 0.2f));
            }
            
        }
    }

    public int GetCurrentHealth()
    {
        return curGateHealthPoint;
    }

    IEnumerator FreezeTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }

    public void Victory(bool b)
    {
        isVictory = b;
    }
}
