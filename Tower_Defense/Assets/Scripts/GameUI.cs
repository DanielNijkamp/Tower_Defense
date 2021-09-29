using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public int PlayerHealth = 100;
    public int PlayerWealth = 200;
    public TextMeshProUGUI WealthText;
    public Toggle speedToggle;
    public GameObject GameOverCanvas;
    public GameObject GameOverSelect;
    public Animator gameoverTransition;

    private void Start()
    {
        WealthText.text = PlayerWealth + " ";
    }
    public void Endgame()
    {
        StartCoroutine(EndGameTransition());

    }
    IEnumerator EndGameTransition()
    {
        Time.timeScale = 1;
        GameOverCanvas.SetActive(true);
        yield return new WaitForSeconds(1);
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
        FindObjectOfType<MainMenuScript>().Transition.SetTrigger("Add_Transition");
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<MainMenuScript>().Transition.SetTrigger("Start");
        FindObjectOfType<SoundManagerScript>().StopMusic();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartGameOverMusic());
        yield return new WaitForSeconds(1f);
        FindObjectOfType<MainMenuScript>().Transition.SetTrigger("End");
        Time.timeScale = 0;
        GameOverSelect.SetActive(true);
    }
    public void ChangeSpeed()
    {
        if (speedToggle.isOn == true)
        {
            Time.timeScale = 3f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    private void Awake()
    {
        speedToggle.isOn = false;
    }

}
