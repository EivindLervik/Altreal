using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTools {

    private DAO dao;

    public NetworkTools()
    {
        dao = new DAO(true);
        dao.Connect();
    }

    public bool IsConnected()
    {
        return dao.IsConnected;
    }

}
