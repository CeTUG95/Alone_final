using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    private AudioSource sources;
    [SerializeField] AudioClip clip;

    void Start()
    {
        SetWeaponActive();
        sources = GetComponent<AudioSource>();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void ProcessKeyInput()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            sources.Play();

            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
   
    }

    
}
