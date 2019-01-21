using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressingOptions : MonoBehaviour
{

    public List<ClothingOption> body;
    public List<ClothingOption> hair;
    public List<ClothingOption> eyes;
    public List<ClothingOption> nose;
    public List<ClothingOption> mouth;
    public List<ClothingOption> t_shirt;
    public List<ClothingOption> pants;
    public List<ClothingOption> shoes;
    public List<ClothingOption> pets;
    public List<ClothingOption> makeup;

    public Dictionary<string, List<ClothingOption>> dressingOptions;

    private void Awake()
    {
        dressingOptions = new Dictionary<string, List<ClothingOption>>();
        dressingOptions.Add("Body", body);
        dressingOptions.Add("Hair", hair);
        dressingOptions.Add("Eyes", eyes);
        dressingOptions.Add("Nose", nose);
        dressingOptions.Add("Mouth", mouth);
        dressingOptions.Add("T_Shirt", t_shirt);
        dressingOptions.Add("Pants", pants);
        dressingOptions.Add("Shoes", shoes);
        dressingOptions.Add("Pets", pets);
        dressingOptions.Add("Makeup", makeup);
    }

}
