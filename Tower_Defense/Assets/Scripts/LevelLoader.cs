using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public static LevelLoader Instance;
    public Animator Transition;
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        FindObjectOfType<SoundManagerScript>().PlayTransitionSFX();
        
        
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
        Debug.Log("Loaded scene");
        Transition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        Transition.SetTrigger("Remove_Transition");
        

    }
    private void Awake()
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
    public void Update()
    {
      
    }
    
}
