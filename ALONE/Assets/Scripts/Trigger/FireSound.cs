using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] AudioClip clip;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }
}
