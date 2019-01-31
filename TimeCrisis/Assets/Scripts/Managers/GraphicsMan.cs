using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Graphics manager.
/// Created as a singleton as only one instance of it is needed in the project
/// </summary>
public class GraphicsMan : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // Singleton architecture
    public static GraphicsMan Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //////////////////////////////////////////////////////
    // Graphics variables

    /// <summary>
    /// Screen width and height values
    /// </summary>
    public float width, height;
    /// <summary>
    /// Screen fullsreen state
    /// </summary>
    public bool fullscreen;

    private void Start()
    {
        // Initialize data with screen values on launch
        width = Screen.width;
        height = Screen.height;
        fullscreen = Screen.fullScreen;
    }

    /// <summary>
    /// Fullscreen toggle
    /// Change from windowed to fullscreen and vice versa
    /// </summary>
    public void FullScreen()
    {
        fullscreen = !fullscreen;
        Screen.SetResolution((int)width, (int)height, !Screen.fullScreen);
    }

    /// <summary>
    /// Apply the new screen resolution values received.
    /// </summary>
    /// <param name="width">Width of the new screen resolution to be applied</param>
    /// <param name="height">Height of the new screen resolution to be applied</param>
    public void ChangeRes(float width, float height)
    {
        Screen.SetResolution((int)width, (int)height, Screen.fullScreen);
    }
}
