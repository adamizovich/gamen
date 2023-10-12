using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSIC : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;

    void Start()
    {
        src.clip = clip;
        src.Play();
    }
}
