using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ColorChoose : MonoBehaviour
{[SerializeField]
    public Color newPlayerColor;
    public string htmlValue;
    public Material PlayerMat;
    public Renderer rend;
    void Start()
    {
        htmlValue = PlayerPrefs.GetString("CharacterColor");
        switch (htmlValue)
        {
            case "red":
                PlayerMat.color = Color.red;
                break;
            case "blue":
                PlayerMat.color = Color.blue;
                break;
            case "green":
                PlayerMat.color = Color.green;
                break;
            case "yellow":
                PlayerMat.color = Color.yellow;
                break;
            case "cyan":
                PlayerMat.color = Color.cyan;
                break;
            case "pink":
                PlayerMat.color = Color.magenta;
                break;
            case "white":
                PlayerMat.color = Color.white;
                break;
            case "black":
                PlayerMat.color = Color.black;
                break;
        }; 
        Debug.Log(PlayerPrefs.GetString("CharacterColor"));
    }
    void Update()
    {
        newPlayerColor = PlayerMat.color;
    }
    public void Red()
    {
        PlayerMat.color = Color.red;
        PlayerPrefs.SetString("CharacterColor", "red");
    }
    public void Blue()
    {
        PlayerMat.color = Color.blue;
        PlayerPrefs.SetString("CharacterColor", "blue");
    }
    public void Green()
    {
        PlayerMat.color = Color.green;
        PlayerPrefs.SetString("CharacterColor", "green");
    }
    public void Yellow()
    {
        PlayerMat.color = Color.yellow;
        PlayerPrefs.SetString("CharacterColor", "yellow");
    }
    public void Pink()
    {
        PlayerMat.color = Color.magenta;
        PlayerPrefs.SetString("CharacterColor", "magenta");
    }
    public void Cyan()
    {
        PlayerMat.color = Color.cyan;
        PlayerPrefs.SetString("CharacterColor", "cyan");
    }
    public void White()
    {
        PlayerMat.color = Color.white;
        PlayerPrefs.SetString("CharacterColor", "white");
    }
    public void Black()
    {
        PlayerMat.color = Color.black;
        PlayerPrefs.SetString("CharacterColor", "black");
    }
}
