using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WCSkillManager : MonoBehaviour
{
    //.. Damage -> "Skill To Enemy Class" (Attach to Monster Prefab)
    [SerializeField] float countdownTime = 60f;
    [SerializeField] ParticleSystem meteor;
    [SerializeField] Image skillImage; // Filler image..

    [SerializeField] private GameObject path1;
    [SerializeField] private GameObject path2;
    private WCPath pathComp1;
    private WCPath pathComp2;

    bool ready = false;
    bool isCooldown = false;

    void Awake()
    {
        skillImage.fillAmount = 1;
        isCooldown = true;

        if (path1 == null)
        {
            return;
        }
        else
        {
            pathComp1 = path1.GetComponent<WCPath>();
        }

        if (path2 == null)
        {
            return;
        }
        else
        {
            pathComp2 = path2.GetComponent<WCPath>();
        }
    }

    private void Update()
    {
        if (isCooldown)
        {
            skillImage.fillAmount -= 1 / countdownTime * Time.deltaTime;

            if(skillImage.fillAmount <= 0)
            {
                isCooldown = false;
                skillImage.fillAmount = 0;
            }
        }
    }

    public void SpawnMeteor()
    {

        if (ready == false && isCooldown == false)
        {
            ready = true;
            isCooldown = true;
            StartCoroutine(Skill());
            skillImage.fillAmount = 1;
        }

    }

    IEnumerator Skill()
    {
        if (ready == true)
        {
            GameObject Meteor;
            Meteor = new GameObject("Meteor");

            meteor.gameObject.GetComponent<ParticleSystem>();

            if (path1 && pathComp1)
            {
                for (int i = 0; i < pathComp1.waypoints.Length - 1; i++)
                {
                    var my = GameObject.Instantiate(meteor, pathComp1.waypoints[i].position = new Vector3(pathComp1.waypoints[i].position.x, 17.38f, pathComp1.waypoints[i].position.z), pathComp1.waypoints[i].rotation);
                    my.transform.parent = GameObject.Find("Meteor").gameObject.transform;
                }
            }

            if (path2 && pathComp2)
            {
                for (int i = 0; i < pathComp2.waypoints.Length - 1; i++)
                {
                    var mz = GameObject.Instantiate(meteor, pathComp2.waypoints[i].position = new Vector3(pathComp2.waypoints[i].position.x, 17.38f, pathComp2.waypoints[i].position.z), pathComp2.waypoints[i].rotation);
                    mz.transform.parent = GameObject.Find("Meteor").gameObject.transform;
                }
            }

            yield return new WaitForSeconds(2.0f);
            Destroy(Meteor);

            ready = false;
        }
       
    }
}