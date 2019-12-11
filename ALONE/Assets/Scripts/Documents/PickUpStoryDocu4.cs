using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStoryDocu4 : MonoBehaviour
{
    public GameObject docu;
    public GameObject document;
    public GameObject reticle;

    private AudioSource source;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        reticle = GameObject.Find("UI/ReticleCanvas/Reticle");
        document = GameObject.Find("UI/StatsCanvas/AllDocuments/MilitiaLog4");
        docu = GameObject.FindGameObjectWithTag("StoryDocument4");
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip);
            Destroy(docu, 13);
            document.SetActive(true);
            reticle.SetActive(false);
            Deactivate(reticle);
            Destroy(document, 13);
            StartCoroutine(Activate(reticle));
        }
    }

    void Deactivate(GameObject g)
    {
        g.SetActive(false);
    }

    IEnumerator Activate(GameObject g)
    {
        yield return new WaitForSeconds(12.94f);
        g.SetActive(true);
    }
}
