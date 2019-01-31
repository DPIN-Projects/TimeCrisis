using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float width, height;
    public bool fullscreen;

    private void Start()
    {
        width = Screen.width;
        height = Screen.height;
        fullscreen = Screen.fullScreen;
    }

    public void FullScreen()
    {
        fullscreen = !fullscreen;
        Screen.SetResolution((int)width, (int)height, !Screen.fullScreen);
    }

    public void ChangeRes(float width, float height)
    {
        Screen.SetResolution((int)width, (int)height, Screen.fullScreen);
    }
}
