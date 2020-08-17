using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gunSound, hitSound, startSound, endSound;
    public AudioSource audioSource;
    
    public void GunSound()
    {
        audioSource.PlayOneShot(gunSound);
    }

    public void HitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
    public void StartSound()
    {
        audioSource.PlayOneShot(startSound);
    }
    public void EndSound()
    {
        audioSource.PlayOneShot(endSound);
    }

}
