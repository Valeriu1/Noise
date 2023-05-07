using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackYouDead : MonoBehaviour
{
    public bool allowCollision = true;
    private void OnTriggerEnter(Collider other)
    {
        if(allowCollision){
            Debug.Log("Collision");
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("You died");
            }
        }   
    }
}
