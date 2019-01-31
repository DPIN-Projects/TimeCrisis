using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    Toggle t_fullscreen;

	// Use this for initialization
	void Start ()
    {
        t_fullscreen = GetComponent<Toggle>();
        t_fullscreen.isOn = GraphicsMan.Instance.fullscreen;
        t_fullscreen.onValueChanged.AddListener(ChangeFullScreenMode);
	}
	
	void ChangeFullScreenMode(bool val)
    {
        GraphicsMan.Instance.FullScreen();
    }
}
