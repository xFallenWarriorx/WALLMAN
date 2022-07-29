using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    public Text versionText;
    public Text bundleText;
    
    // Start is called before the first frame update
    void Start()
    {
        versionText.text = "Version: " + Application.version.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
