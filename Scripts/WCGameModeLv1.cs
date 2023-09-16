using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCGameModeLv1 : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;

    [SerializeField]
    private GameObject gameCanvas;

    private bool isPause;

    void Start()
    {
        FindObjectOfType<WCSoundManager>().PlaySound("BattleThemSound");

        isPause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !FindObjectOfType<WCSceneLoader>().isOver)
        {
            if (isPause = !isPause)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }

        }
    }

    public void PauseGame()
    {
        pauseCanvas.SetActive(true );
        gameCanvas.SetActive (false);

        StartCoroutine(FreezeTime());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        gameCanvas.SetActive (true );

        FindObjectOfType<WCSceneLoader>().CloseSettingsCanvas();
    }

    IEnumerator FreezeTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
