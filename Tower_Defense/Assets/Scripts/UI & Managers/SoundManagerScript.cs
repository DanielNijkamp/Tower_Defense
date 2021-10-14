using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip[] BGM;
    public AudioClip[] MainMenuBGM;
    public AudioClip[] GameOverMusic;
    public AudioClip[] BossMusic1;

    public AudioClip[] ButtonHover;
    public AudioClip[] ButtonClicked;
    public AudioClip[] Transition;

    public AudioClip [] RapidFire_Tower;
    public AudioClip [] High_Cal_Tower;
    public AudioClip [] AoE_Tower;
    public AudioClip [] Slow_Tower;
    public AudioClip [] Health_Tower;
    public AudioClip [] Money_Tower;

    public float BGMVolume;
    public float SFXVolume;
    public bool GameStarted = false;
    

    public AudioSource sfxSource;
    public AudioSource bgmSource;
    public AudioSource rapidTowerSource;
    public AudioSource highcalTowerSource;

    public Button StartButton;


    private static SoundManagerScript SoundManager;
    void Start()
    {

        StartCoroutine(StartMainMenuMusic());
        StartMainMenuMusic();

    }

    void Update()
    {

    }
    public void StopMusic()
    {
        bgmSource.Stop();
        GameStarted = true;

    }


    public void ChangeSFXVolume(float value)
    {
        float newVolume = value * 0.01f;
        sfxSource.volume = newVolume;
        SFXVolume = value * 0.01f;
    }
    public void ChangeBGMVolume(float value)
    {
        float newVolume = value * 0.01f;
        bgmSource.volume = newVolume;
        BGMVolume = newVolume;
    }
    public IEnumerator StartBGMMusic()
    {
        while (true && GameStarted == true)
        {
            AudioClip audioClip = BGM[Random.Range(0, BGM.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSecondsRealtime(audioClip.length);
        }
    }
    public IEnumerator StartGameOverMusic()
    {
        while (true)
        {
            AudioClip audioClip = GameOverMusic[Random.Range(0, GameOverMusic.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSecondsRealtime(audioClip.length);
        }
    }

    public IEnumerator StartMainMenuMusic()
    {
        while ((true && GameStarted == false))
        {
            AudioClip audioClip = MainMenuBGM[Random.Range(0, MainMenuBGM.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSecondsRealtime(audioClip.length);
        }
    }
    public void MouseOverButton()
    {
        AudioClip audioClip = ButtonHover[Random.Range(0, ButtonHover.Length)];
        sfxSource.clip = audioClip;
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);

    }
    public void ButtonPressed()
    {
        AudioClip audioClip = ButtonClicked[Random.Range(0, ButtonClicked.Length)];
        sfxSource.clip = audioClip;
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);

    }
    public void PlayTransitionSFX()
    {
        AudioClip audioClip = Transition[Random.Range(0, Transition.Length)];
        sfxSource.clip = audioClip;
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);
    }
    public void PlayRapidFireShot()
    {
        AudioClip audioClip = RapidFire_Tower[0];
        rapidTowerSource.clip = audioClip;
        rapidTowerSource.volume = SFXVolume;
        rapidTowerSource.pitch = (Random.Range(0.6f, 1.2f));
        rapidTowerSource.PlayOneShot(rapidTowerSource.clip);
    }
    public void PlayHC_Shot()
    {
        AudioClip audioClip = High_Cal_Tower[0];
        highcalTowerSource.clip = audioClip;
        highcalTowerSource.volume = SFXVolume;
        highcalTowerSource.pitch = (Random.Range(0.6f, 1f));
        highcalTowerSource.PlayOneShot(highcalTowerSource.clip);
    }


    private void Awake()
    {
        if (!SoundManager)
        {
            DontDestroyOnLoad(gameObject);
            SoundManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

