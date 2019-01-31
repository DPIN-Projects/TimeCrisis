using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public enum LanguageType
    {
        English,
        Spanish,
        NumberOfTypes
    }
    public LanguageType lan_type = LanguageType.English;

    List<TextData> scene_text;

    private void Start()
    {
        scene_text = new List<TextData>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        scene_text.Clear();
        scene_text.AddRange(Resources.FindObjectsOfTypeAll<TextData>());
        LoadLanguage();
    }

    public void LoadLanguage()
    {
        Debug.Log("Text found was: " + scene_text.Count);
        for(int i = 0; i < scene_text.Count; ++i)
        {
            scene_text[i].ShowText();
        }
    }
}
