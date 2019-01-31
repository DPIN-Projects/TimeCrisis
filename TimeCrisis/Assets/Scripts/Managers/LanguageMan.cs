using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Language manager. Manage all language related operations across all scenes.
/// Created as singleton as only one instance is needed.
/// Will locate every object with text property within a scene and apply the correct language
/// </summary>
public class LanguageMan : MonoBehaviour
{
    //////////////////////////////////////////////////////
    // Singleton architecture
    public static LanguageMan Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //////////////////////////////////////////////////////
    // Language variables

    /// <summary>
    /// Every language admitted in the game
    /// </summary>
    public enum LanguageType
    {
        English,
        Spanish,
        /// <summary>
        /// Contains the number of types inside an enum to easen looping operations with enum values
        /// </summary>
        NumberOfTypes
    }
    public LanguageType lan_type = LanguageType.English;

    /// <summary>
    /// All texts within a scene
    /// </summary>
    List<TextData> scene_text;

    private void Start()
    {
        scene_text = new List<TextData>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Execute when a scene is loaded.
    /// Parameters needed only to include as listener of SceneManager.sceneLoaded
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="load"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        scene_text.Clear();
        scene_text.AddRange(Resources.FindObjectsOfTypeAll<TextData>());
        LoadLanguage();
    }

    /// <summary>
    /// Display every text inside the scene in the currently selected language
    /// </summary>
    public void LoadLanguage()
    {
        for(int i = 0; i < scene_text.Count; ++i)
            scene_text[i].ShowText();
    }
}
