using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEvents : MonoBehaviour
{
   private bool justPlayed;

    [Header("Objects")]
    public AudioSource playClip;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(justPlayed == false)
            {
                playClip.Play();

                justPlayed = true;
            }
        }
    }

}
