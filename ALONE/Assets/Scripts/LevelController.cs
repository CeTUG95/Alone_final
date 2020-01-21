using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject harpy;
    private BossHealth health;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        health = harpy.GetComponent<BossHealth>();
    }

    private void Update()
    {
        if (health.GetIsDead())
        {
            source.Stop();
        }
    }
}