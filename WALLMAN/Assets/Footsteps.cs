using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource foot;
    // Start is called before the first frame update
    private void Awake()
    {
        foot = GetComponent<AudioSource>();
    }
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        foot.pitch = Random.Range(0.8f, 1f);
        foot.PlayOneShot(clip);
    }
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
