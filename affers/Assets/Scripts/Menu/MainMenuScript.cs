using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{

    public float transitionTime = 1f;

    public Animator settingsAnim;
    public Animator transition;
    // Start is called before the first frame update
    

    public void StartGame()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettings()
    {
        settingsAnim.SetBool("ShowSettings", true);

    }

    public void HideSettings()
    {
        settingsAnim.SetBool("ShowSettings", false);

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(levelIndex);

    }
}
