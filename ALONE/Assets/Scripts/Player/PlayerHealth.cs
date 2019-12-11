using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject stopPlaying;
    [SerializeField] GameObject stopPlayingRagerBearWhenDead;

    [SerializeField] float lives;
    [SerializeField] Text livesText;

    AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip clip2;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        source = audioSources[0];
        clip = audioSources[1].clip;
        clip2 = audioSources[2].clip;
    }

    // ZOMBIE
    public void TakeDamage(float damage)
    {
        source.PlayOneShot(clip2);

        GetComponent<DamageUi>().ShowDamageImpact();

        lives -= damage;
        livesText.text = "HP: " + lives;

        if(lives <= 0)
        {
            source.PlayOneShot(clip);
            GetComponent<DeathUi>().HandleDeath();

            stopPlaying.SetActive(false);
            stopPlayingRagerBearWhenDead.SetActive(false);
        }
    }

    // HARPY
    public void TakeDamage2(float damage)
    {
        source.PlayOneShot(clip2);

        GetComponent<DamageUi>().ShowDamageImpact();

        lives -= damage;
        livesText.text = "HP: " + lives;

        if (lives <= 0)
        {
            source.PlayOneShot(clip);
            GetComponent<DeathUi>().HandleDeath();

            stopPlaying.SetActive(false);
        }
    }
}
