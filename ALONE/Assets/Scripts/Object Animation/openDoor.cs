using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    [SerializeField] GameObject movingDoor;
    private AudioSource audios;
    [SerializeField] AudioClip doorSound;
    private bool isTriggered = false;


    private void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movingDoor.GetComponent<Animator>().SetTrigger("DoorDouble_Open");

        }

        if (isTriggered == false)
        {
            audios.PlayOneShot(doorSound);
            isTriggered = true;
        }

        if (isTriggered == false)
        {
            audios.Stop();
        }
    }
}
