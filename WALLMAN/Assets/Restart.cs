using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public float restartDelay = 1f;
    public ScoreBoard Score;
    public float transitionTime = 1f;
    public Animator Crossfade;
    public Animator FadeScore;
    public Animator FadeVersion;
    public Animator FadeGameOver;
 public void RestartButton()
    {
        StartCoroutine("RestartDelay");
    }
  public void BackToMenu()
    {
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex - 1));
    }
  IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator LoadAnimation(int levelIndex)
    {
        Crossfade.SetTrigger("Start");
        FadeScore.SetTrigger("End");
        FadeVersion.SetTrigger("End");
        FadeGameOver.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
