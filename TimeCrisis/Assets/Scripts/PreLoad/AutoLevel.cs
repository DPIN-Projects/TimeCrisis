using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Load automatically level after preload
/// </summary>
public class AutoLevel : MonoBehaviour
{
    public string to_level = "";

    private void Start()
    {
        SceneMan.Instance.LoadSceneByName(to_level);
    }
}
