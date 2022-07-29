using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public int numOfHearts = 3;
    public int WallBreakerBought = 0;
    public int ShieldBought = 0;
    public int Multiplier = 1;

    public bool IsClickable = false;
    public bool IsWallBreakerBought = false;
    public bool IsShieldBought = false;
    public Button Heart;
    public Button Breaker;
    public Button Shielder;
    public Button Multi;
    public Sprite x2;
    public Sprite x3;
    public Sprite x4;
    public GameObject menu;
    public GameObject shop;
    public GameObject credits;
    public GameObject AffordText;
    public GameObject Cost1;
    public GameObject Cost2;
    public GameObject Cost3;
    public GameObject Cost4;
    public Animator FadeError;
    public float CoinCost1;
    public float CoinCost2;
    public float CoinCost3;
    public float CoinCost4;
    public float NCost1 = 2000f;
    public float NCost2 = 5000f;
    public float NCost3 = 2000f;
    public float NCost4 = 3000f;
    public Text CoinsCost1;
    public Text CoinsCost2;
    public Text CoinsCost3;
    public Text CoinsCost4;
    public Text Afford;
    public CoinsAmount coins;
    // Start is called before the first frame update
    void Start()
    {
        CoinCost1 = 2000;
        CoinsCost1.text = CoinCost1.ToString();
        numOfHearts = PlayerPrefs.GetInt("numOfHearts", 3); // количество жизней при загрузке нового игрока
        WallBreakerBought = PlayerPrefs.GetInt("WallBreaker", 0); // количество способностей при загрузке нового игрока
        ShieldBought = PlayerPrefs.GetInt("Shield", 0); // количество способностей при загрузке нового игрока
        Multiplier = PlayerPrefs.GetInt("Multiplier", 1); // множитель очков при загрузке нового игрока
        AffordText.SetActive(false);
        if (numOfHearts == 3)
        {
            CoinCost1 = 2000;
            CoinsCost1.text = CoinCost1.ToString();
        }
        if (numOfHearts == 4)
        {
            CoinCost1 = 4000;
            CoinsCost1.text = CoinCost1.ToString();
        }
        if (WallBreakerBought == 1)
        {
            CoinCost2 = 10000;
            CoinsCost2.text = CoinCost2.ToString();
        }
        if (WallBreakerBought == 2)
        {
            CoinCost2 = 15000;
            CoinsCost2.text = CoinCost2.ToString();
        }
        if (ShieldBought == 1)
        {
            CoinCost4 = 6000;
            CoinsCost4.text = CoinCost4.ToString();
        }
        if (ShieldBought == 2)
        {
            CoinCost4 = 9000;
            CoinsCost4.text = CoinCost4.ToString();
        }
        if (Multiplier == 2)
        {
            Multi.image.sprite = x3;
            CoinCost3 = 4000;
            CoinsCost3.text = CoinCost3.ToString();
        }
        if (Multiplier == 3)
        {
            Multi.image.sprite = x4;
            CoinCost3 = 6000;
            CoinsCost3.text = CoinCost3.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShopLimit();
    }
    public void BuyHearts()
    {
        if (coins.Coins >= CoinCost1)
        {
            
            coins.Coins -= CoinCost1;
            CoinCost1 += NCost1;
            CoinsCost1.text = CoinCost1.ToString();
            coins.CoinsCount.text = coins.Coins.ToString();
            numOfHearts = numOfHearts + 1;
            
            if (numOfHearts > 5 )
            {

                numOfHearts = 5;
                StartCoroutine(BuyHeart());
            }
            PlayerPrefs.SetInt("numOfHearts",numOfHearts);
            PlayerPrefs.SetFloat("Coins", coins.Coins);
            //Debug.Log("You bought +1 heart"+"Next cost " + CoinCost1);
        } else
        {
            StartCoroutine(BuyHeart());
        }
    }
    public void BuyWallBreaker()
    {
        if (coins.Coins >= CoinCost2)
        {
            coins.Coins -= CoinCost2;
            CoinCost2 += NCost2;
            CoinsCost2.text = CoinCost2.ToString();
            coins.CoinsCount.text = coins.Coins.ToString();
            WallBreakerBought = WallBreakerBought + 1;
            PlayerPrefs.SetInt("WallBreaker", WallBreakerBought);
            PlayerPrefs.SetFloat("Coins", coins.Coins);
            //Debug.Log("You bought a Wall Breaker!");
            
        }
        else
        {
            StartCoroutine(BuyWallBreakerC());
        }

    }
    public void BuyMultiplier()
    {
        if (coins.Coins >= CoinCost3)
        {
            coins.Coins -= CoinCost3;
            CoinCost3 += NCost3;
            CoinsCost3.text = CoinCost3.ToString();
            coins.CoinsCount.text = coins.Coins.ToString();
            Multiplier = Multiplier + 1;
            PlayerPrefs.SetInt("Multiplier", Multiplier);
            PlayerPrefs.SetFloat("Coins", coins.Coins);
            if (Multiplier == 2)
            {
                Multi.image.sprite = x3;

            }
            if (Multiplier == 3)
            {
                Multi.image.sprite = x4;
            }

        } else
        {
            StartCoroutine(BuyMultiplierC());
        }
    }
    public void BuyShield()
    {
        if (coins.Coins >= CoinCost4)
        {
            coins.Coins -= CoinCost4;
            CoinCost4 += NCost4;
            CoinsCost4.text = CoinCost4.ToString();
            coins.CoinsCount.text = coins.Coins.ToString();
            ShieldBought = ShieldBought + 1;
            PlayerPrefs.SetInt("Shield", ShieldBought);
            PlayerPrefs.SetFloat("Coins", coins.Coins);
            //Debug.Log("You bought a Shield!");
        } else
        {
            StartCoroutine(BuyShieldC());
        }

    }
    public void ShopLimit()
    {
        if (numOfHearts == 5)
        {
            Heart.interactable = false;
            Cost1.SetActive(false);
        }
        if (WallBreakerBought == 3)
        {
            Breaker.interactable = false;
            Cost2.SetActive(false);
        }
        if (ShieldBought == 3)
        {
            Shielder.interactable = false;
            Cost4.SetActive(false);
        }
        if (Multiplier == 4)
        {
            Multi.interactable = false;
            Multi.image.sprite = x4;
            Cost3.SetActive(false);
        }
    }
    IEnumerator BuyShieldC()
    {
        if (coins.Coins < CoinCost4)
        {
            AffordText.SetActive(true);
            Shielder.interactable = false;
            Breaker.interactable = false;
            Heart.interactable = false;
            Multi.interactable = false;
            FadeError.Play("FadeIn");
            Afford.text = "You don't have enough coins!";
            yield return new WaitForSeconds(1);
            FadeError.SetTrigger("End");
            yield return new WaitForSeconds(1);
            AffordText.SetActive(false);
            Shielder.interactable = true;
            Breaker.interactable = true;
            Heart.interactable = true;
            Multi.interactable = true;
            //Debug.Log("You don't have enough coins");
        }
    }
    IEnumerator BuyMultiplierC()
    {
        if (coins.Coins < CoinCost3)
        {
            AffordText.SetActive(true);
            Shielder.interactable = false;
            Breaker.interactable = false;
            Heart.interactable = false;
            Multi.interactable = false;
            FadeError.Play("FadeIn");
            Afford.text = "You don't have enough coins!";
            yield return new WaitForSeconds(1);
            FadeError.SetTrigger("End");
            yield return new WaitForSeconds(1);
            AffordText.SetActive(false);
            Shielder.interactable = true;
            Breaker.interactable = true;
            Heart.interactable = true;
            Multi.interactable = true;
            //Debug.Log("You don't have enough coins");
        }
    }
    IEnumerator BuyWallBreakerC()
    {
        if (coins.Coins < CoinCost2)
        {
            AffordText.SetActive(true);
            Shielder.interactable = false;
            Breaker.interactable = false;
            Heart.interactable = false;
            Multi.interactable = false;
            FadeError.Play("FadeIn");
            Afford.text = "You don't have enough coins!";
            yield return new WaitForSeconds(1);
            FadeError.SetTrigger("End");
            yield return new WaitForSeconds(1);
            AffordText.SetActive(false);
            Shielder.interactable = true;
            Breaker.interactable = true;
            Heart.interactable = true;
            Multi.interactable = true;
            //Debug.Log("You don't have enough coins");
        }
    }
    IEnumerator BuyHeart()
    {
        if (coins.Coins >= CoinCost1)
        {

            if (numOfHearts > 5)
            {
                AffordText.SetActive(true);
                FadeError.Play("FadeIn");
                Afford.text = "You can't get Hearts more than 5!";
                Heart.interactable = false;
                Cost1.SetActive(false);
                yield return new WaitForSeconds(1);
                FadeError.SetTrigger("End");
                yield return new WaitForSeconds(1);
                AffordText.SetActive(false);
                //Debug.Log("You can't get Hearts more than 5");
            }
        }
        else
        {
            AffordText.SetActive(true);
            Heart.interactable = false;
            Breaker.interactable = false;
            FadeError.Play("FadeIn");
            Afford.text = "You don't have enough coins!";
            yield return new WaitForSeconds(1);
            FadeError.SetTrigger("End");
            yield return new WaitForSeconds(1);
            AffordText.SetActive(false);
            Heart.interactable = true;
            Breaker.interactable = true;
            //Debug.Log("You don't have enough coins");
        }
    }
    public void BackToMenu()
    {
        menu.SetActive(true);
        shop.SetActive(false);
        credits.SetActive(true);
    }
}

