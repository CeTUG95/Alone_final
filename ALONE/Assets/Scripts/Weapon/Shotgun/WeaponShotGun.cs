using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotGun : MonoBehaviour
{
    [SerializeField] Recoil recoil;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 15f;
    [SerializeField] float damage = 50.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AmmoShotgun ammo = null;
    [SerializeField] GameObject hitEffect;
    private AudioClip bang;
    private AudioClip shells;
    private AudioClip ammoEmpty;
    private AudioSource audios;

    private bool canShoot = true;
    private float coolDown = 1f;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audios = audioSources[0];
        bang = audioSources[0].clip;
        shells = audioSources[1].clip;
        ammoEmpty = audioSources[2].clip;
    }

    private void PlayAllAudio()
    {
        audios.PlayOneShot(bang);
        audios.PlayOneShot(shells, 0.5f);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
            canShoot = false;
            Invoke("CooledDown", coolDown);
        }
    }

    private void CooledDown()
    {
        canShoot = true;
    }

    private void Shoot()
    {
        if (ammo.GetCurrentAmmo() > 0)
        {
            recoil.Fire();
            PlayMuzzleFlash();
            ProcessRayCast();
            PlayAllAudio();
            ammo.ReduceCurrentAmmo();
        }
        else if (ammo.GetCurrentAmmo() == 0)
        {
            audios.PlayOneShot(ammoEmpty);
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            hitEffectImpact(hit);
            Debug.Log("I hit this thing: " + hit.transform.name);
            // TODO: add some hit effect for visual players
            hitEffectImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            // call a method on EnemyHealth that decreases the enemy's health
            if (target == null)
            {
                return;
            }

            target.TakeDamage(damage);
        }

        else
        {
            return;
        }

    }

    void hitEffectImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
