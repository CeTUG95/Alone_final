using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSoundEffect : MonoBehaviour
{

    private AudioSource source;
    [SerializeField] AudioClip clip;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    void Update()
    {
        
    }
}
