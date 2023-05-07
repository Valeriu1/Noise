using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackYouDead : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You died");
        }
    }
}
