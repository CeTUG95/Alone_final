using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HP;
    public OpponentController opponentController;

    //
    private AudioSource source;
    [SerializeField] AudioClip clip;

    bool isDead = false;

    //
    public ParticleSystem particle;

    private void Start()
    {
        opponentController.GetComponent<OpponentController>().opponentHasAppeared();

        source = GetComponent<AudioSource>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        HP -= damage;
        if (HP <= 0)
        {
            Die();
            source.enabled = false;
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        opponentController.opponentHasDied();
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("die");

        //
        particle.Stop();
    }
}
