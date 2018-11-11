using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIHandler {

    private GUI_Master guiMaster;

    public GUIHandler(GUI_Master guiMaster)
    {
        this.guiMaster = guiMaster;
    }

    public void PromptMenu(GUIMenu menu)
    {
        switch (menu)
        {
            case GUIMenu.Options:
                guiMaster.OpenOptions();
                break;
        }
    }

    public enum GUIMenu
    {
        Options
    }
}
