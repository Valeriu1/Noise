using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackYouDead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You died");
        }
    }
}
