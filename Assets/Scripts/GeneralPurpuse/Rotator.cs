using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationSpeeds;

    void Update()
    {
        transform.Rotate(rotationSpeeds * Time.deltaTime);
    }
}
