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
    public GunShoot gunShoot;
    public bool isPlayerAlive = true;


    public void Dead() //deactivating everything when dead, enable dead canvas
    {
        canvas.SetActive(false);
        youDiedCanvas.SetActive(true);
        playerMovement.enabled = false;
        mouseLook.enabled = false; 
        gunShoot.enabled = false;
        isPlayerAlive = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
