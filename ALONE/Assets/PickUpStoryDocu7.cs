﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStoryDocu7 : MonoBehaviour
{
    public GameObject docu;
    public GameObject document;
    public GameObject reticle;

    private AudioSource source;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        reticle = GameObject.Find("UI/ReticleCanvas/Reticle");
        document = GameObject.Find("UI/StatsCanvas/AllDocuments/MilitiaLog7");
        docu = GameObject.FindGameObjectWithTag("StoryDocument7");
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(clip);
            Destroy(docu, 16);
            document.SetActive(true);
            reticle.SetActive(false);
            Deactivate(reticle);
            Destroy(document, 16);
            StartCoroutine(Activate(reticle));
        }
    }

    void Deactivate(GameObject g)
    {
        g.SetActive(false);
    }

    IEnumerator Activate(GameObject g)
    {
        yield return new WaitForSeconds(15.94f);
        g.SetActive(true);
    }
}
