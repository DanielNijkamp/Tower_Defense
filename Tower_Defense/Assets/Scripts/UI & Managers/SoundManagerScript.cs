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
    public AudioClip [] Acid_Tower;
    public AudioClip [] AoE_Tower;
    public AudioClip [] Slow_Tower;
    public AudioClip [] Health_Tower;
    public AudioClip [] Money_Tower;

    public float BGMVolume;
    public float SFXVolume;
    public bool GameStarted = false;
    

    public AudioSource sfxSource;
    public AudioSource bgmSource;
    public AudioSource RapidTowerSource;
    public AudioSource HighcalTowerSource;
    public AudioSource AoESource;
    public AudioSource Acid_Source;
    public AudioSource Money_Source;
    public AudioSource Health_Source;
    public AudioSource Slow_Source;

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
            bgmSource.Play(0);
            yield return new WaitForSecondsRealtime(audioClip.length);
        }
    }
    public IEnumerator StartGameOverMusic()
    {
        while (true)
        {
            AudioClip audioClip = GameOverMusic[0];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSecondsRealtime(audioClip.length);
        }
    }
    public IEnumerator StartWinMusic()
    {
        while (true)
        {
            AudioClip audioClip = GameOverMusic[1];
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
        RapidTowerSource.clip = audioClip;
        RapidTowerSource.volume = SFXVolume;
        RapidTowerSource.pitch = (Random.Range(0.6f, 1.2f));
        RapidTowerSource.PlayOneShot(RapidTowerSource.clip);
    }
    public void PlayHC_Shot()
    {
        AudioClip audioClip = High_Cal_Tower[0];
        HighcalTowerSource.clip = audioClip;
        HighcalTowerSource.volume = SFXVolume;
        HighcalTowerSource.pitch = (Random.Range(0.6f, 1f));
        HighcalTowerSource.PlayOneShot(HighcalTowerSource.clip);
    }
    public void Play_AoE_Shot()
    {
        AudioClip audioClip = AoE_Tower[Random.Range(0,1)];
        AoESource.clip = audioClip;
        AoESource.volume = SFXVolume;
        AoESource.pitch = (Random.Range(0.6f, 1.2f));
        AoESource.PlayOneShot(AoESource.clip);
    }
    public void Play_Acid_Shot()
    {
        AudioClip audioClip = Acid_Tower[Random.Range(0, 1)];
        Acid_Source.clip = audioClip;
        Acid_Source.volume = SFXVolume;
        Acid_Source.pitch = (Random.Range(0.6f, 1.2f));
        Acid_Source.PlayOneShot(Acid_Source.clip);
    }
    public void Play_Money_Sound(int begin, int end)
    {
        AudioClip audioClip = Money_Tower[Random.Range(begin,end)];
        Money_Source.clip = audioClip;
        Money_Source.volume = SFXVolume;
        Money_Source.pitch = (Random.Range(0.6f, 1.2f));
        Money_Source.PlayOneShot(Money_Source.clip);
    }
    public void Play_Health_Sound()
    {
        AudioClip audioClip = Health_Tower[Random.Range(0, Health_Tower.Length)];
        Health_Source.clip = audioClip;
        Health_Source.volume = SFXVolume;
        Health_Source.pitch = (Random.Range(0.6f, 1.2f));
        Health_Source.PlayOneShot(Health_Source.clip);
    }
    public void Play_Slow_Sound(int soundclip)
    {
        AudioClip audioClip = Slow_Tower[soundclip];
        Slow_Source.clip = audioClip;
        Slow_Source.volume = SFXVolume;
        Slow_Source.pitch = (Random.Range(0.6f, 1.2f));
        Slow_Source.PlayOneShot(Slow_Source.clip);
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

