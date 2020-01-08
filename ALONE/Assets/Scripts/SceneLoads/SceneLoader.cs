using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void ReloadGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;

        GameObject.Find("Player").GetComponent<Footsteps>().enabled = true;
        GameObject.Find("Player").GetComponent<WeaponZoom>().enabled = true;
        GameObject.Find("Rotation").GetComponent<WeaponSwitch>().enabled = true;
        GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenuLoader>().enabled = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
