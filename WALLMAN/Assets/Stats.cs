using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{   public int BrokenWallsInt;
    public int ShieldsUsedInt;
    public Text BrokenWalls;
    public Text ShieldUsed;
    // Start is called before the first frame update
    void Start()
    {
        BrokenWallsInt = PlayerPrefs.GetInt("BrokenWalls");
        ShieldsUsedInt = PlayerPrefs.GetInt("ShieldsUsed");
        BrokenWalls.text = "Broken Walls:" + " " + BrokenWallsInt.ToString();
        ShieldUsed.text = "Shields Used:" + " " + ShieldsUsedInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
