using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for buttons handling the selection of a language stored in order.
/// This class was made to get access to data stored in a persistent singleton created in another scene.
/// </summary>
public class LanguageOptions : MonoBehaviour
{
    /// <summary>
    /// Current selected option
    /// Is initialized in start to get the value held by language manager instead of an arbitrary number
    /// </summary>
    int cur_lan;

    private void Start()
    {
        cur_lan = (int)LanguageMan.Instance.lan_type;
    }

    /// <summary>
    /// Select the next language in the list.
    /// Reproduce the behaviour of a circular doubly linked list
    /// </summary>
    public void NextLanguage()
    {
        ++cur_lan;
        cur_lan = (int)Mathf.Repeat(cur_lan, (int)LanguageMan.LanguageType.NumberOfTypes);
        LanguageMan.Instance.lan_type = (LanguageMan.LanguageType)cur_lan;
        LanguageMan.Instance.LoadLanguage();
    }

    /// <summary>
    /// Select the previous language in the list.
    /// Reproduce the behaviour of a circular doubly linked list.
    /// </summary>
    public void PrevLanguage()
    {
        --cur_lan;
        cur_lan = (int)Mathf.Repeat(cur_lan, (int)LanguageMan.LanguageType.NumberOfTypes);
        LanguageMan.Instance.lan_type = (LanguageMan.LanguageType)cur_lan;
        LanguageMan.Instance.LoadLanguage();
    }
}
