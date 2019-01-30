using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio Manager.
/// Created as singleton as only one instance is needed.
/// </summary>
public class AudioMan : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // Singleton architecture
    public static AudioMan Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //////////////////////////////////////////////////////
    // Audio Variables

    /// <summary>
    /// Background music audio volume
    /// </summary>
    [HideInInspector]
    public float bckgrnd_music_volume;

    /// <summary>
    /// Special effects audio volume
    /// </summary>
    [HideInInspector]
    public float sfx_volume;

}
