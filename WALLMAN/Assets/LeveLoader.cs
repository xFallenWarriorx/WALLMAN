using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeveLoader : MonoBehaviour
{
    public Animator animator;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadAnimation(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
