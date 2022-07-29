using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{

    public CoinsAmount BoughtCoins;
    public GameObject menu;
    public GameObject credits;
    public GameObject version;
    public GameObject coinshop;
    private string fhcoins = "com.fallenstargames.wallman.500coins"; 
    private string thcoins = "com.fallenstargames.wallman.1000coins";
    private string tthcoins = "com.fallenstargames.wallman.2000coins";
    private string fthcoins = "com.fallenstargames.wallman.4000coins";

    public void OnPurchaseComplete(Product product) 
    { if (product.definition.id == fhcoins)
        {
            BoughtCoins.Coins = BoughtCoins.Coins + 500; // добавление 500 монет к той сумме, которая уже есть у игрока
            BoughtCoins.CoinsCount.text = BoughtCoins.Coins.ToString(); // преобразование количества монет в строку для сохранения в данные
            PlayerPrefs.SetFloat("Coins", BoughtCoins.Coins); // сохранение в данные количество монет, которые купил игрок
            Debug.Log("Give Player 500 Coins");
        }
        if (product.definition.id == thcoins)
        {
            BoughtCoins.Coins = BoughtCoins.Coins + 1000; // добавление 1000 монет к той сумме, которая уже есть у игрока
            BoughtCoins.CoinsCount.text = BoughtCoins.Coins.ToString(); // преобразование количества монет в строку для сохранения в данные
            PlayerPrefs.SetFloat("Coins", BoughtCoins.Coins); // сохранение в данные количество монет, которые купил игрок
            Debug.Log("Give Player 1000 Coins");
        }
        if (product.definition.id == tthcoins)
        {
            BoughtCoins.Coins = BoughtCoins.Coins + 2000; // добавление 2000 монет к той сумме, которая уже есть у игрока
            BoughtCoins.CoinsCount.text = BoughtCoins.Coins.ToString(); // преобразование количества монет в строку для сохранения в данные
            PlayerPrefs.SetFloat("Coins", BoughtCoins.Coins); // сохранение в данные количество монет, которые купил игрок
            Debug.Log("Give Player 2000 Coins");
        }
        if (product.definition.id == fthcoins)
        {
            BoughtCoins.Coins = BoughtCoins.Coins + 4000; // добавление 4000 монет к той сумме, которая уже есть у игрока
            BoughtCoins.CoinsCount.text = BoughtCoins.Coins.ToString(); // преобразование количества монет в строку для сохранения в данные
            PlayerPrefs.SetFloat("Coins", BoughtCoins.Coins); // сохранение в данные количество монет, которые купил игрок
            Debug.Log("Give Player 4000 Coins");
        }

    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }
    public void BackToMenu()
    {
        menu.SetActive(true);
        credits.SetActive(true);
        version.SetActive(true);
        coinshop.SetActive(false);
    }
}
