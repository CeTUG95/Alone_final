using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBtnSounds : MonoBehaviour
{

    [SerializeField] AudioSource fx;
    [SerializeField] AudioClip clip;

    void InvokePlayAgain()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    void InvokeExit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        fx.PlayOneShot(clip);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        //Invoke("InvokePlayAgain", 2.0f);
    }

    public void Exit()
    {
        fx.PlayOneShot(clip);
        //Invoke("InvokeExit", 2.0f);
    }
}
