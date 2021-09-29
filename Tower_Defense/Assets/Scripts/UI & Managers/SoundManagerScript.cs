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
    public AudioClip[] ButtonHover;
    public AudioClip[] ButtonClicked;
    public AudioClip[] Transition;

    public float BGMVolume;
    public float SFXVolume;
    public bool GameStarted = false;

    public AudioSource sfxSource;
    public AudioSource bgmSource;

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
        while (true)
        {
            AudioClip audioClip = BGM[Random.Range(0, BGM.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSeconds(audioClip.length);
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
            yield return new WaitForSeconds(audioClip.length);
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
            yield return new WaitForSeconds(audioClip.length);
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

