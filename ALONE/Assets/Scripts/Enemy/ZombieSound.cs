using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    private AudioSource sources;
    [SerializeField] AudioClip clip;

    EnemyHealth health;
    EnemyHealth_Single singleHealth;

    EnemyAi ai;
    EnemyAi_Single singleAi;

    private void Start()
    {
        sources = GetComponent<AudioSource>();

        health = GetComponent<EnemyHealth>();
        singleHealth = GetComponent<EnemyHealth_Single>();

        ai = GetComponent<EnemyAi>();
        singleAi = GetComponent<EnemyAi_Single>();
    }

    private void Update()
    {
        if (/*!singleAi.GetIsProvoked() &&*/ !ai.GetIsProvoked())
        {
            sources.Play();
        }

        if (health.IsDead() /*|| singleHealth.IsDead()*/)
        {
            sources.Stop();
            return;
        }
        
    }
}
