using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used for every button specifically used for handling changes on the screen resolution
/// This class was made to get access to data stored in a persistent singleton created in another scene.
/// This class is given to the object that has access to the data required in the fewest steps possible in the hierarchy.
/// </summary>
public class ResolutionOptions : MonoBehaviour
{
    /// <summary>
    /// Width and height parameters to be applied
    /// </summary>
    public float width, height;
    /// <summary>
    /// Button object
    /// </summary>
    Button b_res;

    private void Start()
    {
        b_res = GetComponent<Button>();
        b_res.onClick.AddListener(ApplyResolution);
    }

    /// <summary>
    /// Change the screen resolution.
    /// Avoid calling Screen.SetResolution from here to have all graphical function calls at most located in only one script.
    /// </summary>
    void ApplyResolution()
    {
        GraphicsMan.Instance.ChangeRes(width, height);
    }
}