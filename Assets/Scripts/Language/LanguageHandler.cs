using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageHandler {

    private Language language;
    private Dictionary<string, string> dictionary;

    public LanguageHandler(Language language)
    {
        LoadLanguage(language);
    }

    public void LoadLanguage(Language language)
    {
        this.language = language;
        dictionary = new Dictionary<string, string>();

        TextAsset lang = Resources.Load<TextAsset>("Languages/" + language.ToString());
        if (lang != null)
        {
            string[] allLines = lang.text.Split(new[] { System.Environment.NewLine }, System.StringSplitOptions.None);

            foreach(string line in allLines)
            {
                string[] lineElems = line.Split(new[] { " <SPACE> " }, System.StringSplitOptions.None);
                dictionary.Add(lineElems[0], lineElems[1]);
            }
        }
    }

    public string GetString(string key)
    {
        return dictionary[key];
    }

    public enum Language
    {
        english, norwegian, japanese
    }

}
