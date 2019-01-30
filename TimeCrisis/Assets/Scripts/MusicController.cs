using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
