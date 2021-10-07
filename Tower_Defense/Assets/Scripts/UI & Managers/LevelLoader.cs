using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public static LevelLoader Instance;
    public Animator Transition;
    //public GameObject _MainMenuCanvas;

    public void Start()
    {
        //GameObject _MainMenuCanvas = FindObjectOfType<MainMenuScript>().MainMenuCanvas;
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
        
        
    }
    
    

    IEnumerator LoadLevel(int levelIndex)
    {

        FindObjectOfType<SoundManagerScript>().StopMusic();
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartBGMMusic());
        Transition.SetTrigger("End");
        yield return new WaitForSecondsRealtime(0.5f);
        Transition.SetTrigger("Remove_Transition");
        yield return new WaitForSecondsRealtime(0.1f);
        Transition.SetTrigger("Remove_Transition");
        Transition.ResetTrigger("Remove_Transition");
        yield break;


    }
     

    void Awake()
    {
        this.InstantiateController();
    }
        private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }


    }
}
 
    

