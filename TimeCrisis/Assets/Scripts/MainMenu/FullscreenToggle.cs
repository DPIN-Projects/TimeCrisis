using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used for toggle of fullscreen mode.
/// This class was made to get access to data stored in a persistent singleton created in another scene.
/// </summary>
public class FullscreenToggle : MonoBehaviour
{
    /// <summary>
    /// Toggle object
    /// </summary>
    Toggle t_fullscreen;
    
	void Start ()
    {
        t_fullscreen = GetComponent<Toggle>();
        t_fullscreen.isOn = GraphicsMan.Instance.fullscreen;
        t_fullscreen.onValueChanged.AddListener(ChangeFullScreenMode);
	}
	
    /// <summary>
    /// Change the fullsreen mode.
    /// Avoid calling Screen.SetResolution from here to have all graphics related function calls within one script. 
    /// </summary>
    /// <param name="val">Unused value</param>
	void ChangeFullScreenMode(bool val)
    {
        GraphicsMan.Instance.FullScreen();
    }
}
