using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyDance : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        if (PlayerPrefs.HasKey("Dance"))
        {
            int danceType = PlayerPrefs.GetInt("Dance");
            animator.Play(danceType == 1 ? "macarena" : "snake");
        }

    }
}
