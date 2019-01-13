using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDresserCanvas : MonoBehaviour
{
    [Header("Objects")]
    public RectTransform sidePanel;
    public RectTransform editorPanel;

    [Header("Values")]
    public float menuMoveSpeed;

    private bool showSidePanel = true;
    private bool showEditorPanel = false;

    void Start()
    {
        
    }

    void Update()
    {
        // Side panel
        Vector3 sidePanelPosition = showSidePanel ? new Vector3(0.0f, sidePanel.position.y, sidePanel.position.z) : new Vector3(-sidePanel.rect.size.x, sidePanel.position.y, sidePanel.position.z);
        sidePanel.position = Vector3.Lerp(sidePanel.position, sidePanelPosition, Time.deltaTime * menuMoveSpeed);
        
        // Side panel
        Vector3 editorPanelPosition = showEditorPanel ? new Vector3(0.0f, editorPanel.position.y, editorPanel.position.z) : new Vector3(editorPanel.rect.size.x, editorPanel.position.y, editorPanel.position.z);
        editorPanel.position = Vector3.Lerp(editorPanel.position, editorPanelPosition, Time.deltaTime * menuMoveSpeed);


    }

    public void OpenEditor(string editor)
    {
        switch (editor)
        {
            case "Body":
                Debug.Log(editor);
                break;
            case "Hair":
                Debug.Log(editor);
                break;
            case "Eyes":
                Debug.Log(editor);
                break;
            case "Nose":
                Debug.Log(editor);
                break;
            case "Mouth":
                Debug.Log(editor);
                break;
            case "Makeup":
                Debug.Log(editor);
                break;
            case "T-Shirt":
                Debug.Log(editor);
                break;
            case "Pants":
                Debug.Log(editor);
                break;
            case "Shoes":
                Debug.Log(editor);
                break;
            case "Pets":
                Debug.Log(editor);
                break;
            default:
                Debug.LogWarning("This editor is not implemented yet: " + editor + "!");
                return;
        }

        ToggleSidePanel(false);
        ToggleEditorPanel(true);

    }

    public void CloseEditor()
    {


        ToggleEditorPanel(false);
        ToggleSidePanel(true);
    }

    private void ToggleSidePanel(bool on)
    {
        showSidePanel = on;
    }

    private void ToggleEditorPanel(bool on)
    {
        showEditorPanel = on;
    }
}
