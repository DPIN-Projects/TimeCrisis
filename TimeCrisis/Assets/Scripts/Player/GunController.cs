using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gun related operations
/// </summary>
public class GunController : MonoBehaviour
{
    public GunData gun;
    AudioSource audio_src;

    private void Start()
    {
        audio_src = GetComponent<AudioSource>();
        audio_src.volume = AudioMan.Instance.sfx_volume;
    }

    public void FireWeapon()
    {
        audio_src.PlayOneShot(gun.sfx_shot);
    }
}
