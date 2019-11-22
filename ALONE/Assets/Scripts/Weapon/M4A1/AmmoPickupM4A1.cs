using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupM4A1 : MonoBehaviour
{
    [SerializeField] int ammoAmount = 0;
    [SerializeField] float respawnTime = 0f;
    public GameObject respawn;
    private AudioSource audios;
    [SerializeField] AudioClip reload;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audios.PlayOneShot(reload);
            FindObjectOfType<Ammunition>().IncreaseCurrentAmmo(ammoAmount);
            respawn = GameObject.FindGameObjectWithTag("M4A1");
            Invoke("goInactive", 1f);
            Invoke("HideShowObjectAgain", respawnTime);
        }
    }

    void HideShowObjectAgain()
    {
        if (respawn.activeSelf)
        {
            respawn.SetActive(false);
        }
        else
        {
            respawn.SetActive(true);
        }
    }

    void goInactive()
    {
        respawn.SetActive(false);
    }
}
