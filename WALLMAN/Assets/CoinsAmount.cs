using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class CoinsAmount : MonoBehaviour
{
    public bool IsRewarded = false;
    public float Coins;
    public float Add;
    public Text CoinsCount;
    public AudioSource CoinSound;
    // Start is called before the first frame update
    void Start()
    {
        Coins = PlayerPrefs.GetFloat("Coins"); // отобразить количество монет в сохранённых данных "Coins"
        CoinsCount.text = Coins.ToString();
        Canvas.ForceUpdateCanvases();
        CoinsCount.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
        CoinsCount.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
