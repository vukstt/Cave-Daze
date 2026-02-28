using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSIC : MonoBehaviour
{
    //AudioSource music;
    void Start()
    {
        //music = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        //music.Play();
    }

    void Update()
    {
        
    }
}
