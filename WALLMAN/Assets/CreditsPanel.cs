using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPanel : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Credits;
    bool IsPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreditsAppear()
    {
        IsPressed = !IsPressed;
        if (IsPressed == true)
        { 
        Menu.SetActive(false);
        Credits.SetActive(true);
        }

    }
    public void CreditsDisappear()
    {
        if (IsPressed == false)
        { 
        Menu.SetActive(true);
        Credits.SetActive(false);
        }
    }
}
