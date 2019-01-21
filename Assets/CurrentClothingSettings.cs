using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurrentClothingSettings
{

    public Dictionary<string, ClothingSetting> clothingSettings;

    public CurrentClothingSettings()
    {
        clothingSettings = new Dictionary<string, ClothingSetting>();
        clothingSettings.Add("Body", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Hair", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Eyes", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Nose", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Mouth", new ClothingSetting(0, Color.red));
        clothingSettings.Add("T_Shirt", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Pants", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Shoes", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Pets", new ClothingSetting(0, Color.red));
        clothingSettings.Add("Makeup", new ClothingSetting(0, Color.red));
    }
}

public class ClothingSetting
{

    public int type;
    public Color color;

    public ClothingSetting(int type, Color color)
    {
        this.type = type;
        this.color = color;
    }
}
