using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCVictoryCanvas : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource)
        {
            audioSource.volume = PlayerPrefs.GetFloat("SFXSoundSettings");
        }
    }
}
