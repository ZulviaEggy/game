using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Range(0,1)]
    public float volume = 1f;
    public bool isMute;

    public AudioClip musicGameClip;
    private AudioSource audioSource;

    public static MusicManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            audioSource = GetComponent<AudioSource>();
            //if scene 1, if scene menu
            if (true)
                PlayMusic1();
        }
    }
    private void PlayClip(AudioClip clip){
        if(!isMute){
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.volume = volume;
        }
    }
    public void PlayMusic1(){
        PlayClip(musicGameClip);
    }
    public void OnVolumeChanged(float vol){
        volume = vol;
        audioSource.volume = volume;
    }

    public void OnToggleMusic(bool vol){
        isMute = !vol;
        if(isMute){
            audioSource.Stop();
        }
        else{
            audioSource.Play();
        }
    }
}
