using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWallUp : MonoBehaviour
{

    
    [SerializeField] GameObject movingWall;
    private AudioSource audios;
    private AudioClip moveWall;
    private AudioClip terminalButton;
    private bool isTriggered = false;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audios = audioSources[0];
        moveWall = audioSources[0].clip;
        terminalButton = audioSources[1].clip;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movingWall.GetComponent<Animator>().SetTrigger("move");
            
        }

        if (isTriggered == false)
        {
            audios.PlayOneShot(moveWall);
            audios.PlayOneShot(terminalButton);
            isTriggered = true;
        }

        if (isTriggered == false)
        {
            audios.Stop();
        }
    }
}
