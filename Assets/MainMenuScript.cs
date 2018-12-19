﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    private enum State
    {
        Preparing, MainMenu, Login, Connecting, Info, Options, Game
    }

    [Header("Title Screen")]
    public Transform title;
    public Transform mainCamera;
    public GameObject startPanel;
    public float prepareTime;
    public float zoomInTime;
    public Vector3 cameraRestingPosition;
    private Vector3 cameraInitialPosition;
    public Vector3 titleRestingPosition;

    [Header("Menu Elements")]
    public RectTransform mainMenuPivot;
    public RectTransform loginPivot;
    public RectTransform connectingPivot;
    public RectTransform infoPivot;
    public RectTransform optionsPivot;

    [Header("Faders")]
    public float faderFadeTime;
    public Image whiteout;
    private bool whiteout_on;
    public Image blackout;
    private bool blackout_on;

    private bool preparing;
    private State state;

    private void Awake()
    {
        mainMenuPivot.position = new Vector3(-Screen.width, mainMenuPivot.position.y, mainMenuPivot.position.z);
        state = State.Preparing;

        whiteout.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        blackout.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        blackout.color = Color.Lerp(blackout.color, new Color(0.0f, 0.0f, 0.0f, blackout_on ? 1.0f : 0.0f), Time.deltaTime * faderFadeTime);
        whiteout.color = Color.Lerp(whiteout.color, new Color(1.0f, 1.0f, 1.0f, whiteout_on ? 1.0f : 0.0f), Time.deltaTime * faderFadeTime);

        if (preparing)
        {
            if (startPanel.activeSelf)
            {
                startPanel.SetActive(false);
            }
            title.transform.localPosition = Vector3.Lerp(title.localPosition, titleRestingPosition, Time.deltaTime * prepareTime);

            if (state == State.Connecting)
            {
                mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.localPosition, cameraInitialPosition, Time.deltaTime * prepareTime);
            }
            else if (state == State.Game)
            {
                mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.localPosition, Vector3.zero, Time.deltaTime * zoomInTime * 0.01f);
            }
            else
            {
                mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.localPosition, cameraRestingPosition, Time.deltaTime * prepareTime);
            }
        }

        switch (state)
        {
            case State.Preparing:
                mainMenuPivot.position = Vector3.Lerp(mainMenuPivot.position, new Vector3(-Screen.width, Screen.height, mainMenuPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                loginPivot.position = Vector3.Lerp(loginPivot.position, new Vector3(Screen.width, loginPivot.position.y, loginPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                connectingPivot.position = Vector3.Lerp(connectingPivot.position, new Vector3(Screen.width, connectingPivot.position.y, connectingPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                infoPivot.position = Vector3.Lerp(infoPivot.position, new Vector3(infoPivot.position.x, Screen.height * 2, infoPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                break;
            case State.MainMenu:
                mainMenuPivot.position = Vector3.Lerp(mainMenuPivot.position, new Vector3(0.0f, Screen.height, mainMenuPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                loginPivot.position = Vector3.Lerp(loginPivot.position, new Vector3(Screen.width, loginPivot.position.y, loginPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                infoPivot.position = Vector3.Lerp(infoPivot.position, new Vector3(infoPivot.position.x, Screen.height * 2, infoPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                //loginPivot.localEulerAngles = Vector3.Slerp(loginPivot.localEulerAngles, new Vector3(0.0f, 90.0f, 0.0f), Time.deltaTime * prepareTime * 5.0f);
                break;
            case State.Login:
                mainMenuPivot.position = Vector3.Lerp(mainMenuPivot.position, new Vector3(-Screen.width, mainMenuPivot.position.y, mainMenuPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                loginPivot.position = Vector3.Lerp(loginPivot.position, new Vector3(0.0f, loginPivot.position.y, loginPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                connectingPivot.position = Vector3.Lerp(connectingPivot.position, new Vector3(Screen.width, connectingPivot.position.y, connectingPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                //loginPivot.localEulerAngles = Vector3.Slerp(loginPivot.localEulerAngles, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * prepareTime * 5.0f);
                break;
            case State.Connecting:
                loginPivot.position = Vector3.Lerp(loginPivot.position, new Vector3(-Screen.width, loginPivot.position.y, loginPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                connectingPivot.position = Vector3.Lerp(connectingPivot.position, new Vector3(0.0f, connectingPivot.position.y, connectingPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                break;
            case State.Info:
                mainMenuPivot.position = Vector3.Lerp(mainMenuPivot.position, new Vector3(mainMenuPivot.position.x, 0.0f, mainMenuPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                infoPivot.position = Vector3.Lerp(infoPivot.position, new Vector3(infoPivot.position.x, Screen.height, infoPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                break;
            case State.Game:
                connectingPivot.position = Vector3.Lerp(connectingPivot.position, new Vector3(-Screen.width, connectingPivot.position.y, connectingPivot.position.z), Time.deltaTime * prepareTime * 5.0f);
                break;
        }
    }

    public void Prepare()
    {
        cameraInitialPosition = mainCamera.transform.localPosition;
        startPanel.SetActive(false);
        preparing = true;
        state = State.MainMenu;
    }

    public void GoToLogin()
    {
        state = State.Login;
        StopCoroutine("Connect");
    }

    public void GoToMainMenu()
    {
        state = State.MainMenu;
    }

    public void GoToConnect()
    {
        state = State.Connecting;
        StartCoroutine("Connect");
    }

    public void GoToInfo()
    {
        state = State.Info;
    }

    public void GoToOptions()
    {
        state = State.Options;
    }

    public void GoToGame()
    {
        state = State.Game;
        StartCoroutine("FadeOutAndStartGame");
    }

    IEnumerator Connect()
    {
        InGameHandler.Network_Authenticate();
        yield return new WaitForSeconds(3.0f);
        GoToGame();
    }

    IEnumerator FadeOutAndStartGame()
    {
        yield return new WaitForSeconds(0.5f);
        whiteout_on = true;

        while (whiteout.color.a < 0.99f)
        {
            yield return new WaitForEndOfFrame();
        }

        blackout.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        blackout_on = true;
        whiteout_on = false;

        while (whiteout.color.a > 0.01f)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
