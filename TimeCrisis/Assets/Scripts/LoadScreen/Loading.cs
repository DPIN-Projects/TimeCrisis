using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load a scene in the background while in the loading screen.
/// Code extracted from "Unity: Tema6" - building a loading screen
/// </summary>
public class Loading : MonoBehaviour
{
    /// <summary>
    /// Object is enabled at start of the scene. Start loading the next scene immediately.
    /// </summary>
    void OnEnable()
    {
        SceneManager.LoadSceneAsync(SceneMan.Instance.GetLoadScene(), LoadSceneMode.Additive);
        SceneManager.sceneLoaded += FinishLoading;
    }

    /// <summary>
    /// Destroy self at the end of the loading cycle of the next scene.
    /// Function attributes added to allow function be subscribe to event SceneManager.sceneLoaded
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void FinishLoading(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= FinishLoading;
        Destroy(this.gameObject);
    }

}
