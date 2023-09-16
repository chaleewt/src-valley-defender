using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCWaveSpawnerManager : MonoBehaviour
{
    //.. Path info for being assign to monster instance
    [SerializeField] private GameObject path;

    [System.NonSerialized]
    public WCPath pathComp;

    //.. 

    [SerializeField] private GameObject[] monsterPrefab;

    [SerializeField] private Transform location;

    [SerializeField]
    private float minTimeBetweenWave = 5f;

    [SerializeField]
    private float maxTimeBetweenWave = 10f;

    private float countdown;

    private int roundIndex  = 0;

    bool spawn = true;

    void Awake()
    {
        pathComp = path.GetComponent<WCPath>();

        countdown = minTimeBetweenWave;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnMonster());

            float rand = Random.Range(minTimeBetweenWave, maxTimeBetweenWave);
            countdown = rand;
        }

        countdown -= Time.deltaTime;

        //.. Reset Round Index
        if (roundIndex > 5)
        {
            roundIndex = 0;
        }
    }

    IEnumerator SpawnMonster()
    {
        for (int i = 0; i < roundIndex; i++)
        {
            //.. Telling Compilier that this is not correct value but will be given the correct value after
            int monsterIndex = -1;

            if (Random.value <= 0.8) // 80%
            {
                monsterIndex = 0;
            }
            if (Random.value <= 0.50) // 50%
            {
                monsterIndex = 1;
            }

            if (Random.value <= 0.30) // 30%
            {
                monsterIndex = 2;
            }

            if (monsterIndex > -1)
            {
                GameObject mc = Instantiate(monsterPrefab[monsterIndex], location.position, location.rotation);
                mc.GetComponent<WCFollowPath>().GetPath(pathComp);
            }

            yield return new WaitForSeconds(1f);
        }

        
        int rand = Random.Range(0, 5);
        roundIndex += rand;
        spawn = true;
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}
