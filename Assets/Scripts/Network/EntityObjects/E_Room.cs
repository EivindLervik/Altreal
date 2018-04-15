using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class E_Room : E_Object {

    public E_Room(JSONNode dbObject)
    {
        base.SetupObject(dbObject["transform"]);


    }

}
