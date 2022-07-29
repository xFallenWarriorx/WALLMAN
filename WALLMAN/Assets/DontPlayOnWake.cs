using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontPlayOnWake : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Awake()
    {
        music.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
