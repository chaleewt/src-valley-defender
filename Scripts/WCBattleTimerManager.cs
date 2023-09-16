using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WCBattleTimerManager : MonoBehaviour
{
    [SerializeField]
    private float battleTime = 10;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private float minutes, seconds;

    void Awake()
    {
        minutes = battleTime;
        seconds = battleTime;
    }

    void Update()
    {
        if (battleTime >= 0)
        {
            battleTime -= Time.deltaTime;
        }
        else
        {
            battleTime = 0;
        }

        //.. Time Out & You Win
        if (minutes <= 0 && seconds <= 0 && FindObjectOfType<WCValleyGate>().GetCurrentHealth() > 0)
        {
            StartCoroutine(TimeOut());
        }

        DisplayTime(battleTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator TimeOut()
    {
        FindObjectOfType<WCSceneLoader>().LoadVictoryCanvas();
        FindObjectOfType<WCSoundManager>().sounds[1].audioSource.volume = 0;
        FindObjectOfType<WCValleyGate>().Victory(true);

        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
