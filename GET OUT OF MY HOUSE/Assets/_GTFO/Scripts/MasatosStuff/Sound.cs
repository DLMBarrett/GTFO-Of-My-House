using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup mixGroup;

    public bool loop = false;
    [HideInInspector]
    public AudioSource source;
}
