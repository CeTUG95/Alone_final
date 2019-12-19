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
    [SerializeField] Button btn;
    [SerializeField] EventSystem eventSys;

    private void Start()
    {
        gameOverUi.enabled = false;
        btn = GameObject.Find("PlayAgainButton").GetComponent<Button>();
        eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void HandleDeath()
    {
        gameOverUi.enabled = true;
        reticle.enabled = false;
        Time.timeScale = 0;

        GameObject.Find("Player").GetComponent<Footsteps>().enabled = false;
        GameObject.Find("Player").GetComponent<WeaponZoom>().enabled = false;
        GameObject.Find("Rotation").GetComponent<WeaponSwitch>().enabled = false;
        GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenuLoader>().enabled = false;

        eventSys.SetSelectedGameObject(btn.gameObject);
    }

}
