using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;


public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    //public GameObject LoadingCanvas;
    public GameObject SettingsCanvas;
    public GameObject SecretCanvas;
    public VideoClip TrolClip;
    float myFloat;
    public Animator Transition;
    private bool isCoolDown;

    private bool IsTrolling = false;
    //Loading screen wip


    //public Slider slider;
    //public TextMeshProUGUI ProgressText;

    //public GameObject MainMenuBackButton;
    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSecondsRealtime(1f);
        isCoolDown = false;
    }
    public void Start()
    {
        myFloat = (float)TrolClip.length;
        Transition = FindObjectOfType<LevelLoader>().Transition;
    }
    public void StartNewScene()
    {
        if (!isCoolDown)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
            StartCoroutine(CoolDown());
        }
       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        if (!isCoolDown)
        {
            StartCoroutine(OpenSettingsTransition());
            FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
            StartCoroutine(CoolDown());
        }
    }
    public void CloseSettings()
    {
        if (!isCoolDown)
        {
            StartCoroutine(CloseSettingsTransition());
            FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator OpenSettingsTransition()
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        MainMenuCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
        Transition.SetTrigger("End");

    }
    IEnumerator CloseSettingsTransition()
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        MainMenuCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        Transition.SetTrigger("End");
    }

    
    public void TrolPlayer()
    {
        StartCoroutine(Trolcommand());
        FindObjectOfType<SoundManagerScript>().StopMusic();
        IsTrolling = true;
    }
    IEnumerator Trolcommand()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(5);
        yield return new WaitForSeconds(myFloat);
        Application.Quit();

    }
    private void OnApplicationQuit()
    {
        if (IsTrolling)
        {
            Application.OpenURL("https://www.youtube.com/channel/UCuNQHiZDizZF9ErJEi8Gzzg");
        }
        
    }




}
