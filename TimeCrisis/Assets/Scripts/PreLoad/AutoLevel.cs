using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLevel : MonoBehaviour
{
    public string to_level = "";

    private void Start()
    {
        SceneMan.Instance.LoadSceneByName(to_level);
    }
}
