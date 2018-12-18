using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    private enum State
    {
        Preparing, MainMenu, Login, Connecting, Info, Options
    }

    public Transform title;
    public Transform mainCamera;
    public GameObject startPanel;
    public float prepareTime;
    public Vector3 cameraRestingPosition;
    private Vector3 cameraInitialPosition;
    public Vector3 titleRestingPosition;

    public RectTransform mainMenuPivot;
    public RectTransform loginPivot;
    public RectTransform connectingPivot;
    public RectTransform infoPivot;
    public RectTransform optionsPivot;

    private bool preparing;
    private State state;

    private void Awake()
    {
        mainMenuPivot.position = new Vector3(-Screen.width, mainMenuPivot.position.y, mainMenuPivot.position.z);
        state = State.Preparing;
    }

    void Start()
    {
        
    }

    void Update()
    {
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
    }

    public void GoToMainMenu()
    {
        state = State.MainMenu;
    }

    public void GoToConnect()
    {
        state = State.Connecting;
    }

    public void GoToInfo()
    {
        state = State.Info;
    }

    public void GoToOptions()
    {
        state = State.Options;
    }
}
