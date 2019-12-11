using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_Single : MonoBehaviour
{
    [SerializeField] float HP;
    bool isDead = false;
    //
    private AudioSource source;
    [SerializeField] AudioClip clip;

    private void Start()
    {
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
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("die");
    }
}
