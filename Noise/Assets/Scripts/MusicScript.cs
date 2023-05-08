using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
