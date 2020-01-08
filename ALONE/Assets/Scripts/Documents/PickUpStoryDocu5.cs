using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStoryDocu5 : MonoBehaviour
{
    //public GameObject docu;
    public GameObject document;
    public GameObject reticle;

    private AudioSource source;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        reticle = GameObject.Find("UI/ReticleCanvas/Reticle");
        document = GameObject.Find("UI/StatsCanvas/AllDocuments/MilitiaLog5");
        //docu = GameObject.FindGameObjectWithTag("StoryDocument5");
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip);
            document.SetActive(true);
            reticle.SetActive(false);
            Deactivate(reticle);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Circle"))
        {
            Time.timeScale = 1f;
            Activate(reticle);
            document.SetActive(false);
            GameObject.Find("Player").GetComponent<Footsteps>().enabled = true;
            GameObject.Find("Player").GetComponent<WeaponZoom>().enabled = true;
            GameObject.Find("M4A1_PBR").GetComponent<Weapon>().enabled = true;
            GameObject.Find("Rotation").GetComponent<WeaponSwitch>().enabled = true;
            GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenuLoader>().enabled = true;
        }
    }

    void Deactivate(GameObject g)
    {
        g.SetActive(false);
        Time.timeScale = 0f;
        GameObject.Find("Player").GetComponent<Footsteps>().enabled = false;
        GameObject.Find("Player").GetComponent<WeaponZoom>().enabled = false;
        GameObject.Find("M4A1_PBR").GetComponent<Weapon>().enabled = false;
        GameObject.Find("Rotation").GetComponent<WeaponSwitch>().enabled = false;
        GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenuLoader>().enabled = false;
    }

    void Activate(GameObject g)
    {
        g.SetActive(true);
    }
}
