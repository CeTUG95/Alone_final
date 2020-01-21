using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] float HP;

    public bool isDead = false;

    //
    private AudioSource source;
    [SerializeField] AudioClip clip;
    //
    [SerializeField] GameObject portal;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        //
        portal.SetActive(false);
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
        portal.SetActive(true);
    }

    public bool GetIsDead()
    {
        return isDead;
    }

}
