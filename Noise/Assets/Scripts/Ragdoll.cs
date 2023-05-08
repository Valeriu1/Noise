using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    ZombieAttackYouDead[] zombieAttackYouDeads;
    Animator animator;
    Follow followScript;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        zombieAttackYouDeads = GetComponentsInChildren<ZombieAttackYouDead>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        followScript = GetComponent<Follow>();
        Deactivate();
    }

    public void Deactivate()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        animator.enabled = true;
        followScript.enabled = true;
        audioSource.enabled = true;
        foreach (var zombie in zombieAttackYouDeads)
        {
            zombie.allowCollision = true;
        }
    }

    public void Activate()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        animator.enabled = false;
        followScript.enabled = false;
        audioSource.enabled = false;
        foreach (var zombie in zombieAttackYouDeads) //disable zomdamage when dead
        {
            zombie.allowCollision = false;
        }
    }
}
