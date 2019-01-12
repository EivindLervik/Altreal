using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreetViewCanvas : MonoBehaviour
{
    public Text clock;

    void Start()
    {
        
    }

    void Update()
    {
        clock.text = InGameHandler.Settings_GetUseMilitaryTime() ? (System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString()) : System.DateTime.Now.ToShortTimeString();
    }
}
