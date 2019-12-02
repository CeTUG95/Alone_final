using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupShotgun : MonoBehaviour
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
            FindObjectOfType<AmmoShotgun>().IncreaseCurrentAmmo(ammoAmount);
            respawn = GameObject.FindGameObjectWithTag("Shotgun");
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
