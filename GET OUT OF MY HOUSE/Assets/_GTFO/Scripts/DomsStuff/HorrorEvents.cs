using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEvents : MonoBehaviour
{
    [Header("EventType")]
    public bool phoneRing;
    public bool noisemaker;

    [Header("Objects")]
    public AudioSource playClip;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playClip.Play();
        }
    }

}
