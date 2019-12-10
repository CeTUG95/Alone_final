using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage2(damage);
        Debug.Log("BOSS ATTACKED PLAYER");

    }
}
