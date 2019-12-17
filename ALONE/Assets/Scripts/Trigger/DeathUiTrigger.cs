using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeathUiTrigger : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip clip;

    [SerializeField] Canvas gameOverUi;
    [SerializeField] Canvas reticle;
    [SerializeField] Button btn;
    [SerializeField] EventSystem eventSys;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip);
            gameOverUi.enabled = true;
            reticle.enabled = false;
            Time.timeScale = 0;
            eventSys.SetSelectedGameObject(btn.gameObject);
        }
    }
}
