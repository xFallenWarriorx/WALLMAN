using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Animator Crossfade;
    public Animator FadeHealth;
    public Animator FadeScore;
    public Animator FadeJoystick;
    public Animator FadeCoins;
    public Animator FadePause;
    public Animator FadeVersion;
    public static bool gameIsPaused;
    public GameObject PauseObj;
    public GameObject PauseB;
    public GameObject ResumeB;
    public GameObject arbuttons;
    public GameObject settings;
    public GameObject coins;
    public ScoreBoard score;
    public float transitionTime = 1f;


    void Update()
    {
        
    }
    public void ResumeGame()
    {
        PauseObj.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        //AudioListener.pause = false;
        PauseB.SetActive(true);
        ResumeB.SetActive(false);
        score.scoreIncreasing = true;
        arbuttons.SetActive(true);
        coins.SetActive(false);
    }
   public void PauseGame()
    {
        PauseObj.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        //AudioListener.pause = true;
        PauseB.SetActive(false);
        ResumeB.SetActive(true);
        score.scoreIncreasing = false;
        arbuttons.SetActive(false);
        coins.SetActive(true);

    }
    public void SettingsGame()
    {
        settings.SetActive(true);
        PauseObj.SetActive(false);
        ResumeB.SetActive(false);
        PauseB.SetActive(false);
        coins.SetActive(false);

    }
    public void BackToPause()
    {
        settings.SetActive(false);
        PauseObj.SetActive(true);
        ResumeB.SetActive(true);
        coins.SetActive(true);
    }
    public void ExitGame()
    {
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex - 1));
        Time.timeScale = 1f;
    }
    IEnumerator LoadAnimation(int levelIndex)
    {
        Crossfade.SetTrigger("Start");
        FadeHealth.SetTrigger("End");
        FadeScore.SetTrigger("End");
        FadeJoystick.SetTrigger("End");
        FadeCoins.SetTrigger("End");
        FadePause.SetTrigger("End");
        FadeVersion.SetTrigger("End");
        FadeVersion.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}