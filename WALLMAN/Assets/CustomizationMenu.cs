using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomizationMenu : MonoBehaviour
{
    public Animator Crossfade;
    public Animator FadeBack;
    public Animator FadePanel;
    public Animator FadeAdvancedPanel;
    public Animator FadeVersion;
    public Animator FadeRotateButtons;
    public Animator FadeAdvancedButton;
    public Animator FadeSimpleButton;
    public GameObject SimplePanel;
    public GameObject AdvancedButton;
    public GameObject AdvancedPanel;
   
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex - 2));
    }
    public void AdvancedColors()
    {
        SimplePanel.SetActive(false);
        AdvancedButton.SetActive(false);
        AdvancedPanel.SetActive(true);
    }
    IEnumerator LoadAnimation(int levelIndex)
    {
        Crossfade.SetTrigger("Start");
        FadeBack.SetTrigger("End");
        FadePanel.SetTrigger("End");
        FadeAdvancedPanel.SetTrigger("End");
        FadeVersion.SetTrigger("End");
        FadeRotateButtons.SetTrigger("End");
        FadeAdvancedButton.SetTrigger("End");
        FadeSimpleButton.SetTrigger("End");



        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
