using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhyAreYouHere : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    private AudioSource source;
    private bool isTriggered = false;

    void Start()
    {
        source = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isTriggered == false)
            {
                source.Play();
                isTriggered = true;
            }

            if (isTriggered == false)
            {
                source.Stop();
            }
        }
    }
}
