using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float lives;
    [SerializeField] Text livesText;

    // ZOMBIE
    public void TakeDamage(float damage)
    {
        lives -= damage;
        livesText.text = "HP: " + lives;

        if(lives <= 0)
        {
            GetComponent<DeathUi>().HandleDeath();
        }
    }

    // HARPY
    public void TakeDamage2(float damage)
    {
        lives -= damage;
        livesText.text = "HP: " + lives;

        if (lives <= 0)
        {
            GetComponent<DeathUi>().HandleDeath();
        }
    }
}
