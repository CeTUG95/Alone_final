using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    public OpponentController opponentController;

    bool isDead = false;

    private void Start()
    {
        opponentController.opponentHasAppeared();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        // GetComponent<EnemyAi>().OnDamageTaken();
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
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
        // Destroy(gameObject);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("die");
    }
}
