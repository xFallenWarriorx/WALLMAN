using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator FadeMenu;
    public Animator FadeCredits;
    public Animator FadeCoins;
    public Animator FadeVersion;
    public Animator Crossfade;
    public GameObject settings;
    public GameObject menu;
    public GameObject shop;
    public GameObject coinshop;
    public GameObject credits;
    public GameObject stats;
    public GameObject language;
    public AudioMixer audioMixer;
    public float transitionTime = 1f;


    void Start()
    {
        AudioListener.pause = false;
    }
    /*public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
    }*/
    public void StartGame()
    {
        LoadNextLevel();
    }
    public void Settings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        credits.SetActive(false);
    }
    public void Shop()
    {
        menu.SetActive(false);
        shop.SetActive(true);
        credits.SetActive(false);
    }
    public void Stats()
    {
        menu.SetActive(false);
        stats.SetActive(true);
        credits.SetActive(false);
    }
    public void StatsBackToMenu()
    {
        menu.SetActive(true);
        stats.SetActive(false);
        credits.SetActive(true);
    }
    public void CoinShop()
    {
        menu.SetActive(false);
        coinshop.SetActive(true);
        credits.SetActive(false);
        shop.SetActive(false);
    }
    public void Customize()
    {
        LoadCustomization();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadCustomization()
    {
        StartCoroutine(LoadAnimation(SceneManager.GetActiveScene().buildIndex + 2));
    }

    IEnumerator LoadAnimation(int levelIndex)
    {
        FadeMenu.SetTrigger("End");
        FadeCredits.SetTrigger("End");
        FadeCoins.SetTrigger("End");
        FadeVersion.SetTrigger("End");
        Crossfade.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
