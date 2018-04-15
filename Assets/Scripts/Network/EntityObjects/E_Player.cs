using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class E_Player : E_Object {

    public E_Player(JSONNode dbObject)
    {
        base.SetupObject(dbObject["transform"]);


    }

}
