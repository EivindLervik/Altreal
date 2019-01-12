using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvirnomentScript : MonoBehaviour
{

    public Transform sunPivot;
    public Light sun;

    void Start()
    {
        
    }

    void Update()
    {
        print((System.DateTime.Now.TimeOfDay.TotalSeconds / 86400) * 360.0f); 
    }
}
