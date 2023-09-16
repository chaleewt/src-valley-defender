using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCSoundManager : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] Slider bgmVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    //.. In Pause Setting
    [SerializeField] Slider bgmSettingSlider;
    [SerializeField] Slider sfxSettingSlider;

    [Header("Sounds")]
    public WCSound[] sounds;

    void Awake()
    {
        InstanceIgnore();

        foreach (WCSound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
        }

        if (bgmVolumeSlider && sfxVolumeSlider)
        {
            if (!PlayerPrefs.HasKey("BGMSoundSettings") && !PlayerPrefs.HasKey("SFXSoundSettings"))
            {
                PlayerPrefs.SetFloat("BGMSoundSettings", 0.5f);
                PlayerPrefs.SetFloat("SFXSoundSettings", 0.5f);
                Load();
            }
            else
            {
                Load();
            }
        }
        else
        {
            //.. Main
            bgmVolumeSlider.value = 0.5f;
            sfxVolumeSlider.value = 0.5f;
        }

        if (bgmSettingSlider && sfxSettingSlider)
        {
            bgmSettingSlider.value = PlayerPrefs.GetFloat("BGMSoundSettings");
            sfxSettingSlider.value = PlayerPrefs.GetFloat("SFXSoundSettings");
        }
    }

    public void PlaySound(string sound)
    {
        switch(sound)
        {
            //.. BGM sfx
            case "MainThemSound":
                sounds[0].audioSource.volume = bgmVolumeSlider.value;
                sounds[0].audioSource.Play();
                sounds[0].audioSource.loop = true;
                break;

            case "BattleThemSound":
                sounds[1].audioSource.volume = bgmVolumeSlider.value;
                sounds[1].audioSource.Play();
                sounds[1].audioSource.loop = true;
                break;

            //.. Hit sfx
            case "CannonShotSound":
                sounds[2].audioSource.volume = sfxVolumeSlider.value;
                sounds[2].audioSource.Play();
                break;

            case "ArrowShotSound":
                sounds[3].audioSource.volume = sfxVolumeSlider.value;
                sounds[3].audioSource.Play();
                break;

            case "MonsterHitSound":
                sounds[4].audioSource.volume = sfxVolumeSlider.value;
                sounds[4].audioSource.Play();
                break;

            case "BombSound":
                sounds[5].audioSource.volume = sfxVolumeSlider.value;
                sounds[5].audioSource.Play();
                break;

            //.. Resource sfx
            case "GoldRecievedSound":
                sounds[6].audioSource.volume = sfxVolumeSlider.value;
                sounds[6].audioSource.Play();
                break;

            case "DiamondRecievedSound":
                sounds[7].audioSource.volume = sfxVolumeSlider.value;
                sounds[7].audioSource.Play();
                break;

            //.. Tower sfx
            case "ArcherTowerPlaceSound":
                sounds[8].audioSource.volume = sfxVolumeSlider.value;
                sounds[8].audioSource.Play();
                break;

            case "CannonTowerPlaceSound":
                sounds[9].audioSource.volume = sfxVolumeSlider.value;
                sounds[9].audioSource.Play();
                break;

            case "DebuffTowerPlaceSound":
                sounds[10].audioSource.volume = sfxVolumeSlider.value;
                sounds[10].audioSource.Play();
                break;

            case "MouseHoverSound":
                sounds[11].audioSource.volume = sfxVolumeSlider.value;
                sounds[11].audioSource.Play();
                break;

            case "VictorySound":
                sounds[12].audioSource.volume = bgmVolumeSlider.value;
                sounds[12].audioSource.Play();
                break;

            case "GameOverSound":
                sounds[13].audioSource.volume = bgmVolumeSlider.value;
                sounds[13].audioSource.Play();
                break;

            case "RedDiamondRecievedSound":
                sounds[14].audioSource.volume = sfxVolumeSlider.value;
                sounds[14].audioSource.Play();
                break;

            case "TowerBuildSound":
                sounds[15].audioSource.volume = sfxVolumeSlider.value;
                sounds[15].audioSource.Play();
                break;
        }
    }

    void InstanceIgnore()
    {
        if (!bgmVolumeSlider && !sfxVolumeSlider)
        {
            bgmVolumeSlider = null;
            sfxVolumeSlider = null;
        }
    }


    public void IncreaseBGMVolume()
    {
        PlaySound("MouseHoverSound");

        bgmVolumeSlider .value += 0.25f;
        bgmSettingSlider.value += 0.25f;

        sounds[0].audioSource.volume = bgmVolumeSlider.value;
        sounds[1].audioSource.volume = bgmVolumeSlider.value;

        Save();
    }

    public void DecreaseBGMVolume()
    {
        PlaySound("MouseHoverSound");

        bgmVolumeSlider .value -= 0.25f;
        bgmSettingSlider.value -= 0.25f;

        sounds[0].audioSource.volume = bgmVolumeSlider.value;
        sounds[1].audioSource.volume = bgmVolumeSlider.value;

        Save();
    }

    public void IncreaseSFXVolume()
    {
        PlaySound("MouseHoverSound");

        sfxVolumeSlider .value += 0.25f;
        sfxSettingSlider.value += 0.25f;

        Save();
    }

    public void DecreaseSFXVolume()
    {
        PlaySound("MouseHoverSound");

        sfxVolumeSlider .value -= 0.25f;
        sfxSettingSlider.value -= 0.25f;

        Save();
    }

    public void Load()
    {
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMSoundSettings");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXSoundSettings");

        bgmSettingSlider.value = PlayerPrefs.GetFloat("BGMSoundSettings");
        sfxSettingSlider.value = PlayerPrefs.GetFloat("SFXSoundSettings");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("BGMSoundSettings", bgmVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXSoundSettings", sfxVolumeSlider.value);

        PlayerPrefs.SetFloat("BGMSoundSettings", bgmSettingSlider.value);
        PlayerPrefs.SetFloat("SFXSoundSettings", sfxSettingSlider.value);
    }
}
