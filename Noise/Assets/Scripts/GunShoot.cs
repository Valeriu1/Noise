using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
      public float damage = 10f;
      public float headDamage = 35f;
      public float range = 100f;
    public float fireRate = 13f;
    public float impactForce = 6f;

    private float nextTimeToFire = 0f;
    private AudioSource gunFireSound;

    public Camera mainCamera;
      public ParticleSystem muzzleFlash;

    public HitEffect hitEffect;

    private void Start()
    {
        gunFireSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (!muzzleFlash.isPlaying) muzzleFlash.Play();
        gunFireSound.PlayOneShot(gunFireSound.clip);
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.CompareTag("Player")) return;

            if (hit.transform.TryGetComponent<Target>(out var target))
            {
                if (hit.collider.CompareTag("head")) // for extra damage
                {
                    target.TakeDamage(headDamage);
                }
                else
                {
                    target.TakeDamage(damage);
                }
                hitEffect.ShowHitEffect(hit, HitEffect.Effects.Impact, 1f);
            }
            else if(hit.transform.TryGetComponent<HitBox>(out var hitBox))
            {
                if (hit.collider.CompareTag("head")) // for extra damage
                {
                    hitBox.OnBulletHit(headDamage);
                }
                else
                {
                    hitBox.OnBulletHit(damage);
                }
                hitEffect.ShowHitEffect(hit, HitEffect.Effects.Blood, 1f);
            }
            else
            {
                hitEffect.ShowHitEffect(hit, HitEffect.Effects.Hole, 4f);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(-hit.normal * impactForce, hit.point, ForceMode.Impulse);
            }
        }
    }

    

}
