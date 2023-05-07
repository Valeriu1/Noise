using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{
    public GameObject canvas;
    public GameObject youDiedCanvas;
    public MouseLook mouseLook;
    public PlayerMovement playerMovement;


    public void Dead()
    {
        canvas.SetActive(false);
        youDiedCanvas.SetActive(true);
        playerMovement.enabled = false;
        mouseLook.enabled = false; 
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
