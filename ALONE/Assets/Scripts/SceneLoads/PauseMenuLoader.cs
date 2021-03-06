﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//

public class PauseMenuLoader : MonoBehaviour
{
    [SerializeField] Canvas PauseMenu;
    [SerializeField] Canvas reticle;
    [SerializeField] Button btn;
    [SerializeField] EventSystem eventSys;
    private bool isPaused;

    private void Start()
    {
        PauseMenu.enabled = false;
        btn = GameObject.Find("BackToMainBtn").GetComponent<Button>();
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Options"))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.enabled = false;
        reticle.enabled = true;
        Time.timeScale = 1f;

        GameObject.Find("Player").GetComponent<Footsteps>().enabled = true;
        GameObject.Find("Player").GetComponent<WeaponZoom>().enabled = true;
        //GameObject.Find("M4A1_PBR").GetComponent<Weapon>().enabled = true;
        //GameObject.Find("MARMO3").GetComponent<Weapon>().enabled = true;
        GameObject.Find("Rotation").GetComponent<WeaponSwitch>().enabled = true;

        isPaused = false;
        eventSys.SetSelectedGameObject(null);
    }

    public void Pause()
    {
        PauseMenu.enabled = true;
        reticle.enabled = false;
        Time.timeScale = 0;
        isPaused = true;

        GameObject.Find("Player").GetComponent<Footsteps>().enabled = false;
        GameObject.Find("Player").GetComponent<WeaponZoom>().enabled = false;
        //GameObject.Find("M4A1_PBR").GetComponent<Weapon>().enabled = false;
        //GameObject.Find("MARMO3").GetComponent<Weapon>().enabled = false;
        GameObject.Find("Rotation").GetComponent<WeaponSwitch>().enabled = false;

        eventSys.SetSelectedGameObject(btn.gameObject);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
