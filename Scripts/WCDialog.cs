using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCDialog : MonoBehaviour
{
    [SerializeField]
    private GameObject storyText1;

    [SerializeField]
    private GameObject storyText2;

    float textTime = 5f;

    float nextSceneTime = 12f;

    WCSceneLoader sceneLoader;

    private void Awake()
    {
        storyText1.SetActive(true);
        sceneLoader = FindObjectOfType<WCSceneLoader>();
    }

    private void Update()
    {
        if (sceneLoader.isDialog)
        {
            if (textTime <= 0)
            {
                OpenNextDialog();
            }
            textTime -= Time.deltaTime;

            if (nextSceneTime <= 0)
            {
                Continue();
            }
            nextSceneTime -= Time.deltaTime;
        }
    }

    public void OpenNextDialog()
    {
        storyText1.SetActive(false);
        storyText2.SetActive(true );
    }

    public void Continue()
    {
        FindObjectOfType<WCSceneLoader>().LoadLevelSelectionCanvas();
    }
}
