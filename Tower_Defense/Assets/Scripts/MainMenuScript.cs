using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    //public GameObject LoadingCanvas;
    public GameObject SettingsCanvas;
    public GameObject SecretCanvas;

    //Loading screen wip


    //public Slider slider;
    //public TextMeshProUGUI ProgressText;

    //public GameObject MainMenuBackButton;
    public void PlayGame(int sceneIndex)
    {
        //StartCoroutine(LoadAsync(sceneIndex));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   
    /*IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");
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




}
