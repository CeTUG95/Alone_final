using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //

    [SerializeField] Canvas flashlightUI;

    //

    Light flashlight;
    bool lightON = false;

    AudioSource source;
    [SerializeField] AudioClip clip;

    void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;

        source = GetComponent<AudioSource>();
        flashlightUI.enabled = true;
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
                //
                flashlightUI.enabled = false;
            } else
            {
                source.Play();
                flashlight.enabled = false;
                lightON = false;
                //
                flashlightUI.enabled = true;
            }
            
            
        }
    }
}
