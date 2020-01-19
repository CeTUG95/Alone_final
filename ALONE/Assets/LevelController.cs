using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public BossAi boss;


    private AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool notProvoked = boss.GetIsProvoked();

        if (!notProvoked)
        {
            audioSource.Play();

        }

    }
}
