
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]

public class Sound
{
    public string name;

    public AudioClip aClip;

    [HideInInspector]
    public AudioSource track;

    [Range (0f,1f)]
    public float volume;

    public bool loop;
}
