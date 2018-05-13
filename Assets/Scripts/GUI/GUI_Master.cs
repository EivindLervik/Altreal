using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Master : MonoBehaviour {

    public GUI_Options guiOptions;

    private void Start()
    {
        CloseAllMenues();
    }

    public void OpenOptions()
    {
        if (!guiOptions.gameObject.activeSelf)
        {
            guiOptions.gameObject.SetActive(true);
            guiOptions.SetUp(new ArrayList());
        }
    }

    private void CloseAllMenues()
    {
        guiOptions.gameObject.SetActive(false);
    }

}
