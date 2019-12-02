using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Recoil recoil;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range;
    [SerializeField] float damage;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Ammunition ammo = null;
    [SerializeField] GameObject hitEffect;
    private AudioClip bang;
    private AudioClip shells;
    private AudioClip ammoEmpty;
    private AudioSource audios;
    
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
        audios.PlayOneShot(shells, 0.1f);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {             
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ammo.GetCurrentAmmo() > 0)
        {
            recoil.Fire();
            PlayMuzzleFlash();
            ProcessRayCastTarget();
            ProcessRayCastTarget_Single();
            ProcessRayCastTarget_Boss();
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

    private void ProcessRayCastTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
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


    private void ProcessRayCastTarget_Single()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth_Single target_single = hit.transform.GetComponent<EnemyHealth_Single>();
            if (target_single == null)
            {
                return;
            }
            target_single.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void ProcessRayCastTarget_Boss()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            BossHealth target_boss = hit.transform.GetComponent<BossHealth>();
            if (target_boss == null)
            {
                return;
            }
            target_boss.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }



    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
