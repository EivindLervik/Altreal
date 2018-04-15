using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class E_Object {

    // Transforms
    protected Vector3 position;
    protected Vector3 rotation;
    protected Vector3 scale;

    // Setup
    protected void SetupObject(JSONNode transform)
    {
        position = new Vector3(transform["position"][0].AsFloat, transform["position"][1].AsFloat, transform["position"][2].AsFloat);
        rotation = new Vector3(transform["rotation"][0].AsFloat, transform["rotation"][1].AsFloat, transform["rotation"][2].AsFloat);
        scale = new Vector3(transform["scale"][0].AsFloat, transform["scale"][1].AsFloat, transform["scale"][2].AsFloat);
    }

}
