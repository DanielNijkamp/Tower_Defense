using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    
    public int PlayerHealth = 100;
    public int PlayerWealth;

    public int startingWealth = 300;
    public int EnemyDeathReward = 75;
    public int EnemyHitReward = 15;
    public int WaveMoney = 100;


    public bool IsPaused;

    public TextMeshProUGUI WealthText;
    public TextMeshProUGUI HealthText;
    public Toggle speedToggle;

    public Toggle SettingsToggle;

    public GameObject GameOverCanvas;
    public GameObject GameOverSelect;

    public GameObject WinCanvas;
    public GameObject AfterWinCanvas;

    public GameObject PauseTransitionCanvas;
    public GameObject PauseUI;

    public GameObject clickmanager;

    public Animator PauseTransition;

    public bool isCoolDown = false;



    private void Start()
    {
        HealthText.text = PlayerHealth + " ";
        speedToggle.isOn = false;
        IsPaused = false;
        PlayerWealth = startingWealth;
        Physics2D.IgnoreLayerCollision(6, 8, true);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Remove_Transition");
    }
    private void Update()
    {
        
        WealthText.text = PlayerWealth + " ";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCoolDown == false)
            {
                if (IsPaused)
                {
                    clickmanager.SetActive(false);
                    Resume();
                }
                else
                {
                    clickmanager.SetActive(true);
                    Pause();
                }
                StartCoroutine(CoolDown());
            }
         
        }
    }
    public void WinGame()
    {
            StartCoroutine(WinGameTransition());
    }
    
    public void Endgame()
    {
        StartCoroutine(EndGameTransition());

    }
    public void EndApplication()
    {
        Application.Quit();
    }

    public void GoToMainmenu()
    {
        if (!isCoolDown)
        {
            StartCoroutine(LoadMainMenu());
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator LoadMainMenu()
    {
        Time.timeScale = 1f;
        //stop music and play transition
        FindObjectOfType<SoundManagerScript>().StopMusic();
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Start");
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
        yield return new WaitForSeconds(0.5f);
        //start main menu music and canvas
        FindObjectOfType<SoundManagerScript>().GameStarted = false;
        yield return new WaitForSeconds(0.1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartMainMenuMusic());
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("End");
       
        

    }
    IEnumerator EndGameTransition()
    {
        FindObjectOfType<LevelLoader>().Transition.ResetTrigger("Remove_Transition");
        Time.timeScale = 1;
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Add_Transition");
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Start");
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
        yield return new WaitForSeconds(1f);
        GameOverCanvas.SetActive(true);
        FindObjectOfType<SoundManagerScript>().StopMusic();
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelLoader>().Transition.ResetTrigger("Start");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Appear_To_End");
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartGameOverMusic());
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("End");
        GameOverSelect.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        
    }
    IEnumerator WinGameTransition()
    {
        FindObjectOfType<LevelLoader>().Transition.ResetTrigger("Remove_Transition");
        Time.timeScale = 1;
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Add_Transition");
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        WinCanvas.SetActive(true);
        FindObjectOfType<SoundManagerScript>().StopMusic();
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<LevelLoader>().Transition.ResetTrigger("Start");
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("Appear_To_End");
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartWinMusic());
        yield return new WaitForSeconds(0.7f);
        FindObjectOfType<LevelLoader>().Transition.SetTrigger("End");
        AfterWinCanvas.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
    public void ChangeSpeed()
    {
        if (speedToggle.isOn == true)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSecondsRealtime(1f);
        isCoolDown = false;
    }
    public void Pause()
    {
        StartCoroutine(PauseGameplay());
    }
    public void Resume()
    {
        StartCoroutine(ResumeGameplay());
    }
   


    public void ToggleSettings()
    {
        if (SettingsToggle.isOn == true)
        {
            Pause();

        }
        else
        {
            Resume();
        }

    }
    IEnumerator ResumeGameplay()
    {
        PauseTransition.SetTrigger("End");
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        PauseTransitionCanvas.SetActive(false);
        IsPaused = false;
        clickmanager.SetActive(true);
    }
    IEnumerator PauseGameplay()
    {
        PauseTransitionCanvas.SetActive(true);
        PauseTransition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(0.5f);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        clickmanager.SetActive(false);
    }
}