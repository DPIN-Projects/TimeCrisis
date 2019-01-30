using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only used for developping purposes.
/// Force Preload scene to be loaded first to avoid changing scenes back and forth
/// each time the project needs to be run
/// </summary>
public class DevPreLoad : MonoBehaviour
{
    private void Awake()
    {
        // Search if object with DontDestroyOnLoad property was created
        GameObject check = GameObject.Find("__app");

        // If not, load Preload scene
        if(check == null)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Preload");
    }
}
