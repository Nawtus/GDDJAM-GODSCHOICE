using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource sfxSource;
    private AudioSource musicSource;

    public AudioClip sfxStorm;
    public AudioClip sfxAttack;
    public AudioClip sfxLoad;
    public AudioClip sfxTsunami;
    public AudioClip sfxTornado;

    public AudioClip mscAmbience;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        sfxSource = GameObject.FindGameObjectWithTag("SFX").GetComponentInChildren<AudioSource>();
        musicSource = GameObject.FindGameObjectWithTag("Music").GetComponentInChildren<AudioSource>();
    }

    public void playSfx(AudioClip sfxClip,float volume)
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    } 
}
