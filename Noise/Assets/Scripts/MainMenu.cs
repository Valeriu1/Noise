using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Slay()
    {
        SceneManager.LoadScene("MainLEvel");
    }

    public void Test()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
        
    
}
