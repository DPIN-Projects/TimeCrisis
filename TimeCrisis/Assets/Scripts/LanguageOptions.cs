using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageOptions : MonoBehaviour
{
    int cur_lan;

    private void Start()
    {
        cur_lan = (int)LanguageMan.Instance.lan_type;
    }

    public void NextLanguage()
    {
        ++cur_lan;
        cur_lan = (int)Mathf.Repeat(cur_lan, (int)LanguageMan.LanguageType.NumberOfTypes);
        LanguageMan.Instance.lan_type = (LanguageMan.LanguageType)cur_lan;
        LanguageMan.Instance.LoadLanguage();
    }

    public void PrevLanguage()
    {
        --cur_lan;
        cur_lan = (int)Mathf.Repeat(cur_lan, (int)LanguageMan.LanguageType.NumberOfTypes);
        LanguageMan.Instance.lan_type = (LanguageMan.LanguageType)cur_lan;
        LanguageMan.Instance.LoadLanguage();
    }
}
