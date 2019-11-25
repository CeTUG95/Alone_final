using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float lives = 100f;
    [SerializeField] Text livesText;

    public void TakeDamage(float damage)
    {
        lives -= damage;
        // lives--;
        livesText.text = "HP: " + lives;

        if(lives <= 0)
        {
            GetComponent<DeathUi>().HandleDeath();
        }
    }
}
