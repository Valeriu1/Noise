using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackYouDead : MonoBehaviour
{
    public bool allowCollision = true;
    public YouDied youDied;

    public void Start()
    {
        youDied = GameObject.FindGameObjectWithTag("GameManager").GetComponent<YouDied>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(allowCollision){
            Debug.Log("Collision");
            if (other.gameObject.CompareTag("Player"))
            {
                youDied.Dead();
            }
        }   
    }
}
