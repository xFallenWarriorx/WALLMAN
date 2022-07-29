using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class CoinSystem : MonoBehaviour
{
    public ScoreBoard score;
    public bool IsRewarded = false;
    public float Coins;
    public float Reward;
    public float NextReward;
    public float NReward;
    public Text CoinsCount;
    
    public AudioSource CoinSound;
    public GameObject CoinCount;
    public Animator Fade;
    // Start is called before the first frame update
    void Start()
    {
        CoinCount.SetActive(false);
        Coins = PlayerPrefs.GetFloat("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        CoinsCount.text = "+" + Reward.ToString();

        if (score.scoreCount >= NextReward)
        {
            Coins = Coins + Reward;
            PlayerPrefs.SetFloat("Coins", Coins);
            IsRewarded = true;
            CoinSound.Play();
            NextReward += NReward;
            StartCoroutine(RewardCheck());
        }
        IEnumerator RewardCheck()
        { 
        if (IsRewarded == true)
        {
            CoinCount.SetActive(true);
            Fade.Play("FadeOut");
             yield return new WaitForSeconds(2);
            IsRewarded = false;
        }
        if (IsRewarded == false)
        {
            CoinCount.SetActive(false);
        }
        }

    }
}
