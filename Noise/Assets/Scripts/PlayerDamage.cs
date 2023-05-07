using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.gameObject.name);
        if (hit.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("You died");
        }
    }
}
