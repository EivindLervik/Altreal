using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clothing Option", menuName = "Altreal/Clothing")]
public class ClothingOption : ScriptableObject
{

    public string clothingName;
    public string clothingDescription;
    public GameObject clothigGameObject;

}
