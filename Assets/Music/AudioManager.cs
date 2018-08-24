using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundsArray;

    public AudioListener listener;

    private Sound Bso;

    void Awake()
    {
         foreach (Sound sound in soundsArray)
        {
            sound.track =  gameObject.AddComponent<AudioSource>();

            //init the clip
            sound.track.clip = sound.aClip;
            sound.track.volume = sound.volume;
            sound.track.loop = sound.loop;

        }
        SetBSO("bso");

    }
    private void Start()
    {
        Bso.track.Play();
    }

    private void Update()
    {        
 
    }



    public void SetBSO(string audioName)
    {
        Sound aud = Array.Find(soundsArray, track => track.name == audioName);

        if (aud == null)
            return;
        else
            Bso = aud;
    }

    public void Play(string audioName)
    {

     Sound aud = Array.Find(soundsArray, track => track.name == audioName);
        
        if (aud == null)
             return;
        else
           aud.track.Play();


        if (audioName == "canada" || audioName == "militar" || audioName == "zombie" || audioName == "donuts")
        {
            Stop("bso");
  
            PlayDelayed("bso",7);// wait 4 resume the bso ( that audios are 7 segs)
        }
    }
    public void PlayDelayed(string audioName,float delay)
    {
        Sound aud = Array.Find(soundsArray, track => track.name == audioName);

        if (aud == null)
            return;
        else
            aud.track.PlayDelayed(delay);

    }

    public void Stop(string audioName)
    {
        Sound aud = Array.Find(soundsArray, track => track.name == audioName);

        if (aud == null)
            return;
        else
            aud.track.Stop();

    }
    public void Pause(string audioName)
    {
        Sound aud = Array.Find(soundsArray, track => track.name == audioName);

        if (aud == null)
            return;
        else
            aud.track.Pause();

    }
    public void Resume(string audioName)
    {
        Sound aud = Array.Find(soundsArray, track => track.name == audioName);

        if (aud == null)
            return;
        else
            aud.track.UnPause();
    }

    //Volume---------------------------------------------
    public void Mute(string name)
    {
        if(name=="music")
        {
                Bso.track.volume = 0f;
        }
        if(name=="master")
        {
            AudioListener.volume = 0f;
        }
    }
    public void SetMasterVolume(Slider MasterVolume)
    {
        AudioListener.volume = MasterVolume.value;
    }

    public void SetMusicVolume(Slider MusicVolume)
    {
        Bso.track.volume = MusicVolume.value;
    }
 
  





}
