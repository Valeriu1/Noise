using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{
    public Canvas canvas;
    public GameObject skelly;
    public Canvas youDiedCanvas;


    public void Dead()
    {
        canvas.enabled = false;
        youDiedCanvas.enabled = true;
        skelly.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
