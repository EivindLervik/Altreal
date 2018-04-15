using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class E_Room : E_Object {

    protected List<E_Object> roomObjects;

    public E_Room(JSONNode dbObject)
    {
        base.SetupObject(dbObject["transform"]);

        roomObjects = new List<E_Object> (dbObject["objects"].AsArray);
    }

}
