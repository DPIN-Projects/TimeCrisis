using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Base for gun customization.
/// </summary>
[CreateAssetMenu(fileName = "New Gun Info", menuName = "Gun Info", order = 0)]
public class GunData : ScriptableObject
{
    public int max_bullets;
    public AudioClip sfx_shot;
}
