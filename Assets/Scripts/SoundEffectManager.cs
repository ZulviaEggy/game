using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectManager : MonoBehaviour
{
    [Range(0,1)]
    public float volume = 1f;
    public bool isMute;

    public AudioClip hitClip;
    public AudioClip coinClip;
    public AudioClip gameOverJingle;
    public AudioClip levelUpJingle;

    private AudioSource audioSource;

    public static SoundEffectManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayClip(AudioClip clip){
        if(!isMute){
            audioSource.PlayOneShot(clip);
            audioSource.volume = volume;
        }
    }
    public void PlayHitClip(){
        PlayClip(hitClip);
    }
    public void PlayCoinClip(){
        PlayClip(coinClip);
    }  

    public void OnVolumeChanged(float vol){
        volume = vol;
        audioSource.volume = volume;
    }

    public void OnToggleSFX(bool vol){
        isMute = !vol;
        if(isMute){
            audioSource.Stop();
        }
        else{
            audioSource.Play();
        }
    }
}
