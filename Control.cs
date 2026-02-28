using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Control : MonoBehaviour
{
    public int enemies;

    public BoxCollider2D barrier;
    
    void Start()
    {
        barrier.enabled = true;
    }

    
    void Update()
    {
        if (enemies <= 0)
        {
            barrier.enabled = false;
        }
    }
}
