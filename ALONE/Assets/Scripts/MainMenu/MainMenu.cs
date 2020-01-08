using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioSource fx;
    [SerializeField] AudioClip clip;

    void InvokePlay()
    {
        SceneManager.LoadScene(4);
    }

    void InvokeExit()
    {
        Application.Quit();
    }

    public void Play()
    {
        fx.PlayOneShot(clip);
        Invoke("InvokePlay", 2.0f);
    }

    public void Exit()
    {
        fx.PlayOneShot(clip);
        Invoke("InvokeExit", 2.0f);
    }

}