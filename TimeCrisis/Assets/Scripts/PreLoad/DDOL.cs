using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Persistent object across all scenes.
/// Every manager in the proyect is added to object with this script instead of having
/// one object per manager. Used to optimize creating too many non-destructible game 
/// objects.
/// </summary>
public class DDOL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
