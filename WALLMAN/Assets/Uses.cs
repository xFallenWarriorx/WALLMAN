using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Uses : MonoBehaviour
{
    public Shield Shld;
    public WallBreaker Brkr;
    public int ShieldBought;
    public int WallBreakerBought;
    public Text ShieldUsesText;
    public Text WallBreakerUsesText;
    public Button ShieldUse;
    public Button WallBreakerUse;
    // Start is called before the first frame update
    void Start()
    {
        WallBreakerBought = PlayerPrefs.GetInt("WallBreaker");
        ShieldBought = PlayerPrefs.GetInt("Shield");
    }

    // Update is called once per frame
    void Update()
    {
        ShieldUses();
        WallBreakerUses();
    }
    public void ShieldUses()
    { 
        if (Shld.ShieldBought == 0)
        {
            ShieldUsesText.text = "0/3";
        }
        if (Shld.ShieldBought == 1)
        {
            ShieldUsesText.text = "1/3";
        }
        if (Shld.ShieldBought == 2)
        {
            ShieldUsesText.text = "2/3";
        }
        if (Shld.ShieldBought == 3)
        {
            ShieldUsesText.text = "3/3";
        }
    }
    public void WallBreakerUses()
    {
        if (Brkr.WallBreakerBought == 0)
        {
            WallBreakerUsesText.text = "0/3";
        }
        if (Brkr.WallBreakerBought == 1)
        {
            WallBreakerUsesText.text = "1/3";
        }
        if (Brkr.WallBreakerBought == 2)
        {
            WallBreakerUsesText.text = "2/3";
        }
        if (Brkr.WallBreakerBought == 3)
        {
            WallBreakerUsesText.text = "3/3";
        }
    }
}
