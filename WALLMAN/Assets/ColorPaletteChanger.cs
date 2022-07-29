using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteChanger : MonoBehaviour
{
    public GameObject SimplePanel;
    public GameObject SimpleButton;
    public GameObject AdvancedButton;
    public GameObject AdvancedPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdvancedColors()
    {
        SimplePanel.SetActive(false);
        SimpleButton.SetActive(true);
        AdvancedButton.SetActive(false);
        AdvancedPanel.SetActive(true);
    }
    public void SimpleColors()
    {
        SimplePanel.SetActive(true);
        SimpleButton.SetActive(false);
        AdvancedButton.SetActive(true);
        AdvancedPanel.SetActive(false);
    }
}
