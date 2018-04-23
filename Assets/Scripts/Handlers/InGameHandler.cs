using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHandler : MonoBehaviour {

    public static NetworkTools networkTools;

	void Start () {
        networkTools = new NetworkTools();
	}

	void Update () {
		
	}
}
