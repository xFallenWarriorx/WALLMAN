using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningInBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
