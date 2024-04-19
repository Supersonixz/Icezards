using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAudio : MonoBehaviour
{
    AudioSource splash;
    // Start is called before the first frame update
    void Start()
    {
        splash = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        splash.Play();
    }
}
