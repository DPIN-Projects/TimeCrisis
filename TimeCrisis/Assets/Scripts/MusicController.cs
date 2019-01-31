using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contoller of the background music.
/// Even though it only changes the volume, any other background music functions will be managed here.
/// </summary>
public class MusicController : MonoBehaviour
{
    AudioSource audio_src;

    private void Start()
    {
        audio_src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audio_src.volume = AudioMan.Instance.bckgrnd_music_volume;
    }
}
