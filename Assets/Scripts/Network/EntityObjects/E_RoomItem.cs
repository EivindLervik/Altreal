using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class E_RoomItem : E_Object {

    public string itemType;
    public string styleName;

    public E_RoomItem (JSONNode dbObject)
    {
        base.SetupObject(dbObject["transform"]);

        itemType = dbObject["itemType"];
        styleName = dbObject["styleName"];
    }
}
