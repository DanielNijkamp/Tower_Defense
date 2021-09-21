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
    //Loading screen wip


    //public Slider slider;
    //public TextMeshProUGUI ProgressText;

    //public GameObject MainMenuBackButton;
    private void Start()
    {
        myFloat = (float)TrolClip.length;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        StartCoroutine(OpenSettingsTransition());
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
    }
    public void CloseSettings()
    {
        StartCoroutine(CloseSettingsTransition());
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
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



    /*IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");
        return null;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";
            yield return null;
        }
        if (operation.isDone)
        {
            LoadingCanvas.SetActive(false);

        }
    }*/
    public void TrolPlayer()
    {
        StartCoroutine(Trolcommand());
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<SoundManagerScript>().StopMusic();
    }
    IEnumerator Trolcommand()
    {
        yield return new WaitForSeconds(5);
        //Application.OpenURL("https://www.youtube.com/channel/UCuNQHiZDizZF9ErJEi8Gzzg");
        yield return new WaitForSeconds(myFloat);
        Application.Quit();

    }




}
