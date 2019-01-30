using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextData : MonoBehaviour
{
    public string eng_text = "";
    public string spa_text = "";

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
