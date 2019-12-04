using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;
using UnityEngine.EventSystems;
//

public class DeathUi : MonoBehaviour
{
    [SerializeField] Canvas gameOverUi;
    [SerializeField] Canvas reticle;
    //
    [SerializeField] Button btn;
    [SerializeField] EventSystem eventSys;
    //

    private void Start()
    {
        gameOverUi.enabled = false;
        //
        btn = GameObject.Find("PlayAgainButton").GetComponent<Button>();
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        //
    }

    public void HandleDeath()
    {
        gameOverUi.enabled = true;
        reticle.enabled = false;
        Time.timeScale = 0;
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        //
        eventSys.SetSelectedGameObject(btn.gameObject);
        //
    }

}
