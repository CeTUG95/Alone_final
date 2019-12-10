using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    Light flashlight;
    bool lightON = false;

    AudioSource source;
    [SerializeField] AudioClip clip;

    void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            if (!lightON)
            {
                source.Play();
                flashlight.enabled = true;
                lightON = true;
            } else
            {
                source.Play();
                flashlight.enabled = false;
                lightON = false;
            }
            
            
        }
    }
}
