using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [HideInInspector]
    public float bckgrnd_music_volume;

    [HideInInspector]
    public float sfx_volume;

}
