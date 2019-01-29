using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    List<EditorBuildSettingsScene> scenes;

    private void Start()
    {
        scenes = new List<EditorBuildSettingsScene>();
        scenes.AddRange(EditorBuildSettings.scenes);
    }

    public void LoadSceneByName(string scene_name)
    {
        string path = "Assets/Scenes/" + scene_name + ".unity";
        if (scenes.Find(x => x.path == path) != null)
            SceneManager.LoadScene(scene_name);
        else
            Debug.Log("Could not load " + scene_name + " scene.");
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
