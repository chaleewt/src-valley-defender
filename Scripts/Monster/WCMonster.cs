using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WCMonster : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private GameObject goldParticle;
    [SerializeField] private GameObject diamondParticle;
    [SerializeField] private GameObject RedDiamondParticle;

    [SerializeField]
    private int maxMonsterHealthPoint = 100;

    [System.NonSerialized]
    public int curMonsterHealthPoint;

    [SerializeField]
    private float diamondDropRate = 0.5f;

    [SerializeField]
    private float redDiamondDropRate = 0.2f;

    [SerializeField]
    private int diamondDropAmount = 1;

    [SerializeField]
    private int redDiamondDropAmount = 1;

    [SerializeField]
    private int goldDropAmount = 20;

    [SerializeField]
    public int damageToGate = 20;

    private AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        curMonsterHealthPoint = maxMonsterHealthPoint;
    }

    public void TakeDamage(int dmg)
    {
        curMonsterHealthPoint -= dmg;
        FindObjectOfType<WCSoundManager>().PlaySound("MonsterHitSound");
    }

    public void Death()
    {
        GameObject deathParticleGO = Instantiate(deathParticle, transform.position, Quaternion.identity);
        if (deathParticleGO)
        {
            //.. Drop Gold & Diamond
            WCBuildingManager buildingManager = FindObjectOfType<WCBuildingManager>();
            if (buildingManager)
            {
                //.. 100% Chance Gold
                buildingManager.GainGold(goldDropAmount);
                FindObjectOfType<WCSoundManager>().PlaySound("GoldRecievedSound");
                Instantiate(goldParticle, transform.position, Quaternion.identity);

                if (Random.value <= redDiamondDropRate) 
                {
                    buildingManager.GainRedDiamond(redDiamondDropAmount);
                    FindObjectOfType<WCSoundManager>().PlaySound("RedDiamondRecievedSound");
                    Instantiate(RedDiamondParticle, transform.position, Quaternion.identity);
                }

                if (Random.value <= diamondDropRate)
                {
                    buildingManager.GainDiamond(diamondDropAmount);
                    FindObjectOfType<WCSoundManager>().PlaySound("DiamondRecievedSound");
                    Instantiate(diamondParticle, transform.position, Quaternion.identity);
                }
            }

            Destroy(deathParticleGO, 1.5f);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CastleGate")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
