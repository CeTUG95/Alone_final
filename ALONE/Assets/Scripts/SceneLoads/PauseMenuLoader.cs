using System.Collections;
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
        isPaused = false;
        eventSys.SetSelectedGameObject(null);
    }

    public void Pause()
    {
        PauseMenu.enabled = true;
        reticle.enabled = false;
        Time.timeScale = 0;
        isPaused = true;
        eventSys.SetSelectedGameObject(btn.gameObject);
        //
        /*vertical navigation must not be possible in pause menu*/
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
