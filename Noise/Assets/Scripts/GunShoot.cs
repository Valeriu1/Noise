using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
      public float damage = 10f;
      public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;

    public Camera mainCamera;
      public ParticleSystem muzzleFlash;
    public GameObject bulletHole;

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
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject tmpBulletHole = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(tmpBulletHole, 3f);
        }
    }
}
