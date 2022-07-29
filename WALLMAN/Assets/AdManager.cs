using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    void Update()
    {
        if (Advertisement.IsReady("Video"))
        {
            Advertisement.Show("Video");
        }
    }
}
