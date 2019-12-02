using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUi : MonoBehaviour
{
    [SerializeField] Canvas gameOverUi;
    [SerializeField] Canvas reticle;

    private void Start()
    {
        gameOverUi.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverUi.enabled = true;
        reticle.enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
