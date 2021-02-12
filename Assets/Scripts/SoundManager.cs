using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public AudioClip ballHitsPaddle;
    public AudioClip ballHitsWall;
    public AudioClip goalClip1;
    public AudioClip goalClip2;
    public AudioClip goalClip3;
    public AudioClip goalClip4;
    public AudioClip goalClip5;

    private AudioSource soundEffect;

    void Start()
    {
        if(Instance == null)        { Instance = this; }
        else if (Instance != this)  { Destroy(gameObject); }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.clip == null)
            {
                soundEffect = source;
            }
        }
    }

    public void call(AudioClip clip)
    {
        soundEffect.PlayOneShot(clip);
    }

    //void Update() { }

}
