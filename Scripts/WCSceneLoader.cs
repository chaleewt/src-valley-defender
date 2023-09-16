using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WCSceneLoader : MonoBehaviour
{
    //.. CANVAS CONFIG
    [SerializeField] GameObject menuCanvas, levelCanvas, gameCanvas;
    [SerializeField] GameObject optionsCanvas, creatorsCanvas;
    [SerializeField] GameObject victoryCanvas, gameOverCanvas;
    [SerializeField] GameObject dialogCanvas, SettingCanvas;
    [SerializeField] GameObject creditCanvas;

    public bool isOver;
    public bool isDialog;

    public void LoadLevelSelectionCanvas()
    {
        levelCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        dialogCanvas.SetActive(false);
    }

    public void LoadMenuCanvas()
    {
        levelCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void LoadOptionsCanvas()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void LoadCreatorsCanvas()
    {
        menuCanvas.SetActive(false);
        creatorsCanvas.SetActive(true);
    }

    public void LoadVictoryCanvas()
    {
        isOver = true;
        victoryCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void LoadGameOverCanvas()
    {
        isOver = true;
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void LoadDialogCanvas()
    {
        isDialog = true;
        dialogCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void LoadSettingsCanvas()
    {
        SettingCanvas.SetActive(true);
    }

    public void CloseSettingsCanvas()
    {
        SettingCanvas.SetActive(false);
    }

    public void LoadCreditCanvas()
    {
        creditCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void CloseCreditCanvas()
    {
        menuCanvas.SetActive(true);
        creditCanvas.SetActive(false);
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////


    void Awake()
    {

        InstanceIgnore();

        isOver = false;
        isDialog = false;

        //.. Set Active To FALSE /////////////////////////////////////////////////////////////////////////
        if (levelCanvas)
        {
            levelCanvas.SetActive(false);
        }

        if (optionsCanvas)
        {
            optionsCanvas.SetActive(false);
        }

        if (creatorsCanvas)
        {
            creatorsCanvas.SetActive(false);
        }

        if (victoryCanvas)
        {
            victoryCanvas.SetActive(false);
        }

        if (gameOverCanvas)
        {
            gameOverCanvas.SetActive(false);
        }

        if (dialogCanvas)
        {
            dialogCanvas.SetActive(false);
        }

        if (SettingCanvas)
        {
            SettingCanvas.SetActive(false);
        }

        if (creditCanvas)
        {
            creditCanvas.SetActive(false);
        }

    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
        isOver = false;
        isDialog = false;
    }

    public void LoadLevel1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BattleLv1");
        isOver = false;
    }

    public void LoadLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BattleLv2");
        isOver = false;
    }

    public void LoadLevel3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BattleLv3");
        isOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        isOver = false;
    }

    private void InstanceIgnore()
    {
        if (!menuCanvas)
            menuCanvas = null;

        if (!levelCanvas)
            levelCanvas = null;

        if (!gameCanvas)
            gameCanvas = null;

        if (!optionsCanvas)
            optionsCanvas = null;

        if (!creatorsCanvas)
            creatorsCanvas = null;

        if (!victoryCanvas)
            victoryCanvas = null;

        if (!gameOverCanvas)
            gameOverCanvas = null;

        if (!dialogCanvas)
            dialogCanvas = null;

        if (!SettingCanvas)
            SettingCanvas = null;

        if (!creditCanvas)
            creditCanvas = null;
    }

}
