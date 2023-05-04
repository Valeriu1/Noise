using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    [HideInInspector]
    public float currentHealth;
    Ragdoll ragdoll;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        ragdoll = GetComponent<Ragdoll>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            MakeItDead();
        }
    }

    private void MakeItDead()
    {
        if (ragdoll != null && ragdoll.isActiveAndEnabled)
        {
            ragdoll.Activate(); //bassically a ragdoll mode
        }
    }
}
