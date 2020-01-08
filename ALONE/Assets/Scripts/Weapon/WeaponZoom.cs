using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera cameraZoom;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToggle = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;
                cameraZoom.fieldOfView = zoomedInFOV;
            }
            else
            {
                zoomedInToggle = false;
                cameraZoom.fieldOfView = zoomedOutFOV;
            }
        }
    }

}
