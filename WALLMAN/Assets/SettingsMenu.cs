using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SettingsMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject credits;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Slider mvolSlider;
    public Slider sevolSlider;
    public Slider muvolSlider;
    public Text mvolText;
    public Text sevolText;
    public Text muvolText;
    const string resName = "resolutionoption";

    Resolution[] resolutions;
    Resolution selectedResolution;

    void Start()
    {
        mvolSlider.value = PlayerPrefs.GetFloat("MVolume", 0.5f);
        sevolSlider.value = PlayerPrefs.GetFloat("SEVolume", 0.5f);
        muvolSlider.value = PlayerPrefs.GetFloat("MUVolume", 0.5f);
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }


    public void BackToMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(true);
    }
    public void MSetVolume(float mvolSlider/*mvolume*/)
    {
        audioMixer.SetFloat("mvolume", Mathf.Log10(mvolSlider/*.value*/) * 20);
        PlayerPrefs.SetFloat("MVolume", mvolSlider/*.value */);
        mvolText.text = Mathf.RoundToInt(mvolSlider/*.value */ * 100) + "%";
        
    }
    public void SESetVolume(float sevolSlider/*sevolume*/)
    {
        audioMixer.SetFloat("sevolume", Mathf.Log10(sevolSlider/*.value*/) * 20);
        PlayerPrefs.SetFloat("SEVolume", sevolSlider/*.value*/);
        sevolText.text = Mathf.RoundToInt(sevolSlider/*.value*/ * 100) + "%";
    }
    public void MUSetVolume(float muvolSlider/*muvolume*/)
    {
        audioMixer.SetFloat("muvolume", Mathf.Log10(muvolSlider/*.value*/) * 20);
        PlayerPrefs.SetFloat("MUVolume", muvolSlider/*.value*/);
        muvolText.text = Mathf.RoundToInt(muvolSlider/*.value*/ * 100) + "%";
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void PrivacyPolicy()
    {
        Application.OpenURL("https://pages.flycricket.io/wallman/privacy.html");
    }
}


