using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10f;
    public bool AudioPlayedThree = false;
    public bool AudioPlayedTwo = false;
    public bool AudioPlayedOne = false;
    public bool AudioPlayedGO = false;
    public Text countdownText;
    public ScoreBoard score;
    public GameObject timer;
    public GameObject arbuttons;
    public GameObject pausebutton;
    public AudioSource audios;
    public AudioSource audioss;
    public AudioSource audiosss;
    public AudioSource audiossss;
    public AudioSource MusicGame;
    public AudioClip Three;
    public AudioClip Two;
    public AudioClip One;
    public AudioClip GO;
    public Timer timerscript;
    void Start()
    {
        pausebutton.SetActive(false);
        arbuttons.SetActive(false);
        Time.timeScale = 0f;
        MusicGame.Stop();
        score.scoreIncreasing = false;
        currentTime = startingTime;

    }
    void Update()
    {
        currentTime -= 1f * Time.unscaledDeltaTime;
        countdownText.text = currentTime.ToString("0");
        if (currentTime > 5 ) AudioPlayedThree = false;
        if (currentTime <= 3f) 
        { if(!AudioPlayedThree)
            {
                audios.PlayOneShot(Three,1);
                AudioPlayedThree = true;
            }
        }
        if (currentTime > 5) AudioPlayedTwo = false;
        if (currentTime <= 2f)
        {
            if (!AudioPlayedTwo)
            {
                audioss.PlayOneShot(Two, 1);
                AudioPlayedTwo = true;
            }
        }
        if (currentTime > 5) AudioPlayedOne = false;
        if (currentTime <= 1f)
        {
            if (!AudioPlayedOne)
            {
                audioss.PlayOneShot(One, 1);
                AudioPlayedOne = true;
            }
        }
        if (currentTime <= 0.99)
        {
            countdownText.text = null;
        }
        if (currentTime > 5) AudioPlayedGO = false;
        if (currentTime <= 0f)
        {
            
            countdownText.text = "GO!";
            if (!AudioPlayedGO)
            { 
                
                audiossss.PlayOneShot(GO, 1);
                AudioPlayedGO = true;
            }
        }
        if (currentTime <= -1f)
        {
            Time.timeScale = 1f;
            MusicGame.Play();
            score.scoreIncreasing = true;
            currentTime = 0;
            timer.SetActive(false);
            timerscript.enabled = false;
            arbuttons.SetActive(true);
            pausebutton.SetActive(true);
        }
    }
}
