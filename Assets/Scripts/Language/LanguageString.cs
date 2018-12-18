using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageString : MonoBehaviour
{
    public string stringTag;

    private Text myText;

    private void Start()
    {
        GetMyString();
    }

    void OnEnable()
    {
        GetMyString();
    }

    private void GetMyString()
    {
        if (!myText)
        {
            myText = GetComponent<Text>();
        }
        if (myText)
        {
            string s = InGameHandler.Language_GetString(stringTag);
            myText.text = s.Equals("") ? myText.text : s;
        }
    }
}
