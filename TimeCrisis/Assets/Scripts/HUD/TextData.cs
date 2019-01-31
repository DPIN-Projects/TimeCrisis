using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class given to every object in the scene with text affected by translation.
/// Objects that hold this component are all accesible from the language manager, 
/// meaning this may be used as a base to future language manager to handle data
/// from a file.
/// </summary>
public class TextData : MonoBehaviour
{
    /// <summary>
    /// English language text
    /// </summary>
    public string eng_text = "";
    /// <summary>
    /// Spanish language text
    /// </summary>
    public string spa_text = "";

    /// <summary>
    /// Display a text depending on the language the language manager currently holds
    /// </summary>
	public void ShowText()
    {
        switch(LanguageMan.Instance.lan_type)
        {
            case LanguageMan.LanguageType.English:
                GetComponent<TextMeshProUGUI>().text = eng_text;
                break;
            case LanguageMan.LanguageType.Spanish:
                GetComponent<TextMeshProUGUI>().text = spa_text;
                break;
            default:
                Debug.Log("Language unknown");
                break;
        }
    }
}
