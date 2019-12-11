using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Footsteps : MonoBehaviour
{
    private AudioSource sources;
    [SerializeField] AudioClip clip;
    RigidbodyFirstPersonController rbfpc;
    
    private void Start()
    {
        sources = GetComponent<AudioSource>();
        rbfpc = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (rbfpc.Grounded == true && rbfpc.Velocity.magnitude > 2f && sources.isPlaying == false)
        {
            sources.Play();
        }
    }

}
