using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using WebSocketSharp;

public class DAO {

    public bool IsConnected { get; private set; }

    private const string serverURL = "ws://demos.kaazing.com/echo";

    private bool dummy;
    private WebSocket webSocketConnection;

    public DAO (bool dummy)
    {
        this.dummy = dummy;
    }

    public void Connect()
    {
        if (dummy)
        {
            webSocketConnection = new WebSocket(serverURL);

            webSocketConnection.OnOpen += OnOpen;
            webSocketConnection.OnMessage += OnMessage;
            webSocketConnection.OnError += OnError;
            webSocketConnection.OnClose += OnClose;

            webSocketConnection.Connect();
        }

        IsConnected = true;
    }

    public void OnOpen(object sender, EventArgs e) // 'e' is empty
    {
        Debug.LogWarning("OPEN: Connected to '" + serverURL + "'");
        webSocketConnection.Send("Blob");
    }

    public void OnMessage(object sender, MessageEventArgs e)
    {
        Debug.LogWarning("MESSAGE: " + e.Data);
    }

    public void OnError(object sender, ErrorEventArgs e)
    {
        Debug.LogWarning("ERROR: " + e.Message);
    }

    public void OnClose(object sender, CloseEventArgs e)
    {
        Debug.LogWarning("CLOSE: (" + e.Code + ") - " + e.Reason);
    }

}
