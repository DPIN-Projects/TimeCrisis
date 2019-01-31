using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene manager.
/// Created as singleton as only one instance is needed.
/// Contains all scene management related functions.
/// </summary>
public class SceneMan : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // Singleton architecture
    public static SceneMan Instance { get; private set; }
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //////////////////////////////////////////////////////
    // Scene Handling

    /// <summary>
    /// All scenes included in editor build settings.
    /// </summary>
    #if UNITY_EDITOR
    List<EditorBuildSettingsScene> scenes;
    #endif

    /// <summary>
    /// Scenes available in the project
    /// </summary>
    public enum SceneIndex
    {
        PreLoad,
        Loading,
        MainMenu,
        Level1
    }
    /// <summary>
    /// Scene to be loaded from the loading screen
    /// </summary>
    SceneIndex scene_to_load;

    private void Start()
    {
        #if UNITY_EDITOR
        // Initialize list with all scenes
        scenes = new List<EditorBuildSettingsScene>();
        scenes.AddRange(EditorBuildSettings.scenes);
        #endif
    }

    /// <summary>
    /// Load scene with specific name. Safety check done before loading new scene.
    /// Loading screen is not called.
    /// </summary>
    /// <param name="scene_name">Name of the scene to be loaded</param>
    public void LoadSceneByName(string scene_name)
    {
        #if UNITY_EDITOR
        // Check wether the scene passed exists in "Scene" file
        string path = "Assets/Scenes/" + scene_name + ".unity";
        if (scenes.Find(x => x.path == path) != null)
            SceneManager.LoadScene(scene_name);
        else
            // Display error
            Debug.Log("Could not load " + scene_name + " scene.");
        #else
            // Cannot check scene names when outside of editor
            SceneManager.LoadScene(scene_name);
        #endif
    }

    /// <summary>
    /// Load scene with specific name via an enum
    /// The function will load LoadScreen first and load the new scene from there
    /// </summary>
    /// <param name="scene_name">Name of the scene to be loaded</param>
    public void LoadSceneByEnum(string scene_name)
    {
        scene_to_load = (SceneIndex)System.Enum.Parse(typeof(SceneIndex), scene_name);
        Debug.Log("To Load " + (int)scene_to_load);
        SceneManager.LoadScene("LoadScreen");
    }

    /// <summary>
    /// Reload current scene
    /// </summary>
    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Get the index of the scene to be loaded after the loading screen
    /// </summary>
    /// <returns>Build index of the scene to be loaded</returns>
    public int GetLoadScene()
    {
        return (int)scene_to_load;
    }
}
