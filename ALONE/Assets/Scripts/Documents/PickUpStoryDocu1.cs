using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStoryDocu1 : MonoBehaviour
{
    public GameObject docu;
    public GameObject document;
    public GameObject reticle;

    private AudioSource source;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        reticle = GameObject.Find("UI/ReticleCanvas/Reticle");
        document = GameObject.Find("UI/StatsCanvas/AllDocuments/MilitiaLog1");
        docu = GameObject.FindGameObjectWithTag("StoryDocument1");
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip);
            Destroy(docu, 15);
            document.SetActive(true);
            reticle.SetActive(false);
            Deactivate(reticle);
            Destroy(document, 15);
            StartCoroutine(Activate(reticle));
        }
    }

    void Deactivate(GameObject g)
    {
        g.SetActive(false);
    }

    IEnumerator Activate(GameObject g)
    {
        yield return new WaitForSeconds(14.94f);
        g.SetActive(true);
    }
}
