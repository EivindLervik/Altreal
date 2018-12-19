using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTools {

    private static DAO dao;

    public NetworkTools()
    {
        Connect();
    }

    public bool IsConnected()
    {
        return dao != null && dao.IsConnected;
    }

    public void Connect()
    {
        if (dao != null)
        {
            dao.Connect();
        }
        else
        {
            dao = new DAO(true);
            dao.Connect();
        }
    }

    public void Authenticate (Func<int> continuation, string username, string password)
    {
        //dao.Authenticate(continuation, username, password);
    }
}
