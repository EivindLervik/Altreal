using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDresserCanvas : MonoBehaviour
{
    [Header("Objects")]
    public RectTransform sidePanel;
    public RectTransform editorPanel;
    public GameObject nextClothingItemButton;
    public GameObject prevClothingItemButton;

    [Header("Values")]
    public float menuMoveSpeed;

    [Header("Dressing Options")]
    public DressingOptions dressingOptions;

    [Header("Bones")]
    public Transform body;
    public Transform hair;
    public Transform eyes;
    public Transform nose;
    public Transform mouth;
    public Transform t_shirt;
    public Transform pants;
    public Transform shoes;
    public Transform pets;
    public Transform makeup;
    private Dictionary<string, Transform> characterBones;

    private bool showSidePanel = true;
    private bool showEditorPanel = false;

    private string currentEditor;
    private List<ClothingOption> selectedClothing;
    private int selectedClothingIndex;
    private Color selectedClothingColor;
    private CurrentClothingSettings currentClothingSettings;
    private Transform currentParentBone;

    void Start()
    {
        currentClothingSettings = InGameHandler.Settings_GetCurrentClothingSettings();

        characterBones = new Dictionary<string, Transform>();
        characterBones.Add("Body", body);
        characterBones.Add("Hair", hair);
        characterBones.Add("Eyes", eyes);
        characterBones.Add("Nose", nose);
        characterBones.Add("Mouth", mouth);
        characterBones.Add("T_Shirt", t_shirt);
        characterBones.Add("Pants", pants);
        characterBones.Add("Shoes", shoes);
        characterBones.Add("Pets", pets);
        characterBones.Add("Makeup", makeup);
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
        currentEditor = editor;

        selectedClothing = dressingOptions.dressingOptions[currentEditor];
        selectedClothingIndex = currentClothingSettings.clothingSettings[currentEditor].type;
        selectedClothingColor = currentClothingSettings.clothingSettings[currentEditor].color;
        currentParentBone = characterBones[currentEditor];

        ToggleSidePanel(false);
        ToggleEditorPanel(true);

        SelectClothing();
    }

    public void CloseEditor()
    {
        currentClothingSettings.clothingSettings[currentEditor].type = selectedClothingIndex;
        currentClothingSettings.clothingSettings[currentEditor].color = selectedClothingColor;
        currentParentBone = null;

        ToggleEditorPanel(false);
        ToggleSidePanel(true);
    }

    public void NextClothingItem()
    {
        selectedClothingIndex++;
        SelectClothing();
    }

    public void PrevClothingItem()
    {
        selectedClothingIndex--;
        SelectClothing();
    }

    public void OpenColorEditor()
    {

    }

    public void CloseColorEditor()
    {

    }

    private void SelectClothing()
    {
        CheckNextAndPrev();

        foreach (Transform child in currentParentBone)
        {
            Destroy(child.gameObject);
        }

        Transform clothing = Instantiate(selectedClothing[selectedClothingIndex].clothigGameObject, currentParentBone).transform;
        clothing.position = new Vector3();
    }

    private void CheckNextAndPrev()
    {
        Mathf.Clamp(selectedClothingIndex, 0, selectedClothing.Count - 1);

        prevClothingItemButton.SetActive(selectedClothingIndex > 0);
        nextClothingItemButton.SetActive(selectedClothingIndex < selectedClothing.Count - 1);
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
